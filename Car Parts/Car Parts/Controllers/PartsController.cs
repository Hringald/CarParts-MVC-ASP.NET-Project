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
        //Choose Make
        public IActionResult ChooseMake()
        {
            var makes = this.data.Makes
             .Select(m => new PartCategoryViewModel
             {
                 Id = m.Id,
                 Name = m.Name,
                 ImageUrl = m.ImageUrl
             }).ToList();

            return View(makes);
        }
        //
        //Add Part
        [Authorize]
        public IActionResult AddPart(string make)
        {
            var makeModel = this.data.Makes.FirstOrDefault(m => m.Name == make);

            return View(new AddPartFormModel
            {
                MakeName = make,
                Categories = this.GetPartCategories(),
                Models = this.GetPartModels(make)
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddPart(AddPartFormModel part)
        {
            if (!this.data.Makes.Any(m => m.Name == part.MakeName))
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
                part.Models = this.GetPartModels(part.MakeName);
                return this.View(part);
            }

            var make = this.data.Makes.FirstOrDefault(m => m.Name == part.MakeName);
            var model = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);
            var sellerId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var partModel = new Part
            {
                Name = part.Name,
                ImageUrl = part.ImageUrl,
                CategoryId = part.CategoryId,
                Category = category,
                MakeId = part.MakeId,
                Make = make,
                ModelId = part.ModelId,
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

        //Info
        [Authorize]
        public IActionResult Info(string id)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == id);

            return View(part);
        }
        //
        //Edit
        [Authorize]
        public IActionResult Edit(string partId)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            var make = this.data.Makes.FirstOrDefault(m => m.Id == part.MakeId);
            var model = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var partModel = new EditPartFormModel
            {
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                MakeName = make.Name,
                ModelName = model.Name,
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                CategoryName = category.Name
            };


            return View(partModel);
        }
        //
        [HttpPost]
        [Authorize]
        public IActionResult Edit(EditPartFormModel part)
        {
            if (!this.data.Makes.Any(m => m.Name == part.MakeName))
            {
                this.ModelState.AddModelError(nameof(part.MakeName), "Make is invalid.");
            }
            if (!this.data.Models.Any(m => m.Name == part.ModelName))
            {
                this.ModelState.AddModelError(nameof(part.ModelName), "Model is invalid.");
            }
            if (!this.data.Categories.Any(c => c.Name == part.CategoryName))
            {
                this.ModelState.AddModelError(nameof(part.CategoryName), "Category is invalid.");
            }

            if (!ModelState.IsValid)
            {
                return this.View(part);
            }

            var partToUpdate = this.data.Parts.FirstOrDefault(p => p.Make.Name == part.MakeName && p.Make.Name == part.MakeName && p.Category.Name == part.CategoryName);


            partToUpdate.Name = part.Name;
            partToUpdate.ImageUrl = part.ImageUrl;
            partToUpdate.Price = part.Price;
            partToUpdate.Quantity = part.Quantity;
            partToUpdate.Description = part.Description;

            this.data.SaveChanges();

            return RedirectToAction("MyOffers", "Offers");
        }
        //
        //Delete
        [HttpGet]
        [Authorize]
        public IActionResult Delete(string partId)
        {
            if (partId==null)
            {
                return BadRequest();
            }

            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            this.data.Parts.Remove(part);
            this.data.SaveChanges();

            return RedirectToAction("MyOffers", "Offers");
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

        private ICollection<PartCategoryViewModel> GetPartModels(string make)
        =>
     this.data
         .Models
         .Where(m => m.Make.Name == make)
         .Select(p => new PartCategoryViewModel
         {
             Id = p.Id,
             Name = p.Name
         }).ToList();
        //IsAdmin
        private bool UserIsAdmin() => this.data.Admins
                .Any(a => a.UserId == this.User.GetId());
    }
}
