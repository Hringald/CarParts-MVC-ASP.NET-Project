using Car_Parts.Data;
using Car_Parts.Data.Models;
using Car_Parts.Infrastructure;
using Car_Parts.Models.Parts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Car_Parts.Controllers
{
    public class PartsController : Controller
    {
        private readonly CarPartsDbContext data;
        public PartsController(CarPartsDbContext data)
        {
            this.data = data;
        }
        //Add Part
        [Authorize]
        public IActionResult AddPart()
        {
            return View(new AddPartFormModel
            {
                Makes = this.GetPartMakes(),
                Categories = this.GetPartCategories(),
                Models = this.GetPartModels()
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPart(AddPartFormModel part)
        {
            if (!this.data.Makes.Any(m => m.Id == part.MakeId))
            {
                this.ModelState.AddModelError(nameof(part.MakeId), "Make is invalid.");
            }
            if (!this.data.Models.Any(m => m.Id == part.ModelId))
            {
                this.ModelState.AddModelError(nameof(part.ModelId), "Model is invalid.");
            }
            if (!this.data.Categories.Any(c => c.Id == part.CategoryId))
            {
                this.ModelState.AddModelError(nameof(part.CategoryId), "Category is invalid.");
            }

            if (!ModelState.IsValid)
            {
                part.Categories = this.GetPartCategories();
                part.Makes = this.GetPartMakes();
                part.Models = this.GetPartModels();
                return this.View(part);
            }

            var make = this.data.Makes.FirstOrDefault(m => m.Id == part.MakeId);
            var model = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);
            var sellerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var partModel = new Part
            {
                Name = part.Name,
                ImageUrl = part.ImageUrl,
                Category = category,
                Make = make,
                Model = model,
                Description = part.Description,
                Quantity = part.Quantity,
                Price = part.Price,
                SellerId = sellerId,
            };

            this.data.Parts.Add(partModel);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        //Add Make
        [Authorize]
        public IActionResult AddMake()
        {
            if (!this.UserIsAdmin())
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }
            return this.View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddMake(AddMakeFormModel make/*, IFormFile makeImage*/)
        {
            var adminId = this.data.Admins
                .Where(a => a.UserId == this.User.GetId())
                .Select(d => d.Id)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(adminId))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }
            /*
            if (makeImage == null || makeImage.Length > 5 * 1024 * 1024)
            {
                this.ModelState.AddModelError("makeImage", "The image is not valid it is required and should be less than 5mb.");
            }
            */
            if (this.data.Makes.Any(m => m.Name == make.Name))
            {
                this.ModelState.AddModelError(nameof(make.Name), "Make already exists.");
            }

            if (!ModelState.IsValid)
            {
                return this.View(make);
            }

            var makeModel = new Make
            {
                Name = make.Name,
                ImageUrl = make.ImageUrl,
                AdminId = adminId
            };

            this.data.Makes.Add(makeModel);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
        //
        //Add Model --------------------------------------------
        [Authorize]
        public IActionResult AddModel()
        {
            if (!this.UserIsAdmin())
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            return View(new AddModelFormModel
            {
                Makes = this.GetPartModelMakes()
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddModel(AddModelFormModel carModel)
        {
            var adminId = this.data.Admins
               .Where(a => a.UserId == this.User.GetId())
               .Select(d => d.Id)
               .FirstOrDefault();

            if (string.IsNullOrEmpty(adminId))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            if (!this.data.Makes.Any(m => m.Id == carModel.MakeId))
            {
                this.ModelState.AddModelError(nameof(carModel.MakeId), "Make is invalid.");
            }

            var make = this.data.Makes.FirstOrDefault(m => m.Id == carModel.MakeId);

            if (this.data.Models.Where(m => m.Make.Name == make.Name).Any(m => m.Name == carModel.Name))
            {
                this.ModelState.AddModelError(nameof(carModel.Name), "Model already exists.");
            }

            if (!ModelState.IsValid)
            {
                carModel.Makes = this.GetPartModelMakes();

                return this.View(carModel);
            }

            var modelModel = new Model
            {
                Name = carModel.Name,
                ImageUrl = carModel.ImageUrl,
                Make = make,
                AdminId = this.User.GetId()
            };

            make.Models.Add(modelModel);
            this.data.Models.Add(modelModel);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
        //
        //Categories
        [Authorize]
        public IActionResult Categories(string make, string model)
        {
            ViewBag.Model = model;
            ViewBag.Make = make;
            var categories = this.data.Categories
                 .Select(c => new PartCategoryViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                     ImageUrl = c.ImageUrl
                 }).ToList();

            return View(categories);
        }
        //
        //ShopPage
        [Authorize]
        public IActionResult ShopPage(string make, string model, string category, string searchTerm, int currentPage)
        {
            var partQuery = this.data.Parts.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                partQuery = partQuery.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalParts = this.data.Parts.Count();

            var parts = partQuery
                .Skip((currentPage - 1) * AllPartsViewModel.PartsPerPage)
                .Take(AllPartsViewModel.PartsPerPage)
                .Where(p => p.Model.Name == model && p.Make.Name == make && p.Category.Name == category)
                .OrderByDescending(p => p.Id)
                .Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    MakeName = p.Make.Name,
                    ModelName = p.Model.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToList();

            var partsModel = new AllPartsViewModel
            {
                Parts = parts,
                Make = make,
                Model = model,
                Category = category,
                TotalParts = totalParts
            };

            return View(partsModel);
        }
        //
        //IsAdmin
        private bool UserIsAdmin() => this.data.Admins
                .Any(a => a.UserId == this.User.GetId());
        //Info
        [Authorize]
        public IActionResult Info(string id)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == id);

            return View(part);
        }
        //
        //private Methods
        private ICollection<PartCategoryViewModel> GetPartMakes()
        =>
            this.data
                .Makes
                .Select(p => new PartCategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();

        private ICollection<PartCategoryViewModel> GetPartModelMakes()
        =>
            this.data
                .Makes
                .Select(p => new PartCategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                }).ToList();

        private ICollection<PartCategoryViewModel> GetPartCategories()
        =>
            this.data
                .Categories
                .Select(p => new PartCategoryViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();

        private ICollection<PartCategoryViewModel> GetPartModels()
        =>
     this.data
         .Models
         .Select(p => new PartCategoryViewModel
         {
             Id = p.Id,
             Name = p.Name
         }).ToList();

    }
}
