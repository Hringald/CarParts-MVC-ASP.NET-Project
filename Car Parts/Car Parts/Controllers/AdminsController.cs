namespace Car_Parts.Controllers
{
    using Car_Parts.Models.Admins;
    using Car_Parts.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Car_Parts.Services.Admins;
    using Car_Parts.Data;
    using Car_Parts.Services.Models;
    using Car_Parts.Services.Parts;
    using System.Linq;
    using Car_Parts.Models.Parts;

    public class AdminsController : Controller
    {
        private readonly CarPartsDbContext data;
        private readonly IAdminsService admins;
        private readonly IModelsService models;
        private readonly IPartsService parts;
        public AdminsController(IAdminsService admins, IModelsService models, IPartsService parts, CarPartsDbContext data)
        {
            this.admins = admins;
            this.data = data;
            this.models = models;
            this.parts = parts;
        }
        [Authorize]
        public IActionResult Become() => this.View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(AddAdminFormModel admin)
        {
            if (this.admins.IsAdmin(this.User.GetId()))
            {
                this.ModelState.AddModelError(nameof(admin.Name), "User is already admin.");
            }

            if (!ModelState.IsValid)
            {
                return View(admin);
            }

            this.admins.AddAdmin(admin.Name, this.User.GetId());

            return this.Redirect("/");
        }
        [Authorize]
        public IActionResult EditMakes()
        {
            var makes = this.data
                .Makes
                .Select(m => new EditMakesViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .OrderByDescending(m => m.Name)
                .ToList();

            return this.View(makes);
        }
        [Authorize]
        public IActionResult EditMake(string makeId)
        {
            var make = this.data.Makes.FirstOrDefault(m => m.Id == makeId);

            var makeModel = new EditMakeFormModel
            {
                Id = make.Id,
                ImageUrl = make.ImageUrl,
                Name = make.Name
            };


            return this.View(makeModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditMake(EditMakeFormModel makeModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(makeModel);
            }

            var make = this.data.Makes.FirstOrDefault(m => m.Id == makeModel.Id);

            make.Name = makeModel.Name;
            make.ImageUrl = makeModel.ImageUrl;

            this.data.SaveChanges();

            return RedirectToAction("EditMakes", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteMake(string makeId)
        {
            var make = this.data.Makes.FirstOrDefault(m => m.Id == makeId);

            this.data.Makes.Remove(make);

            this.data.SaveChanges();

            return RedirectToAction("EditMakes", "Admins");
        }

        [Authorize]
        public IActionResult EditModels()
        {
            var models = this.data
                .Models
                .Select(m => new EditModelsViewModel
                {
                    Id = m.Id,
                    MakeName = m.Make.Name,
                    ModelName = m.Name
                })
                .OrderByDescending(m => m.MakeName)
                .ThenByDescending(m => m.ModelName)
                .ToList();

            return this.View(models);
        }
        [Authorize]
        public IActionResult EditModel(string ModelId)
        {
            var model = this.data.Models.FirstOrDefault(m => m.Id == ModelId);

            var modelModel = new EditModelFormModel
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                MakeId = model.MakeId,
                Name = model.Name,
                Makes = this.models.GetMakes()
            };

            return this.View(modelModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditModel(EditModelFormModel modelModel)
        {
            if (modelModel.MakeId == null)
            {
                return this.Redirect("/");
            }

            if (!this.data.Makes.Any(m => m.Id == modelModel.MakeId))
            {
                this.ModelState.AddModelError(nameof(modelModel.MakeId), "Make is invalid.");
            }

            if (!ModelState.IsValid)
            {
                modelModel.Makes = this.models.GetMakes();

                return this.View(modelModel);
            }

            var model = this.data.Models.FirstOrDefault(m => m.Id == modelModel.Id);
            var make = this.data.Makes.FirstOrDefault(m => m.Id == modelModel.MakeId);

            model.Name = modelModel.Name;
            model.Make = make;
            model.MakeId = make.Id;
            model.ImageUrl = modelModel.ImageUrl;

            this.data.SaveChanges();

            return this.RedirectToAction("EditModels", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteModel(string ModelId)
        {
            var model = this.data.Models.FirstOrDefault(m => m.Id == ModelId);

            this.data.Models.Remove(model);

            this.data.SaveChanges();

            return this.RedirectToAction("EditModels", "Admins");
        }
        [Authorize]
        public IActionResult UsersParts()
        {
            var users = this.data
                .Users
                .Where(u => !this.data.Admins.Any(a => a.UserId == u.Id))
                .Select(u => new UsersPartsViewModel
                {
                    UserId = u.Id,
                    PartsCount = u.Parts.Count(),
                    UserName = u.UserName
                })
                .OrderByDescending(u => u.UserName)
                .ToList();



            return this.View(users);
        }
        [Authorize]
        public IActionResult EditParts(string userId)
        {
            var user = this.data.Users.FirstOrDefault(u => u.Id == userId);

            var partsViewModel = new EditPartsViewModel
            {
                UserId = userId,
                UserName = user.UserName,
                Parts = this.parts.GetMyParts(userId)
            };

            return this.View(partsViewModel);
        }
        [Authorize]
        public IActionResult EditPart(string partId)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            var make = this.data.Makes.FirstOrDefault(m => m.Id == part.MakeId);
            var model = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var categories = this.parts.GetCategories();

            var partModel = new EditPartFormModel
            {
                Id = part.Id,
                Description = part.Description,
                ImageUrl = part.ImageUrl,
                MakeName = make.Name,
                ModelName = model.Name,
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                CategoryId = category.Id,
                Categories = categories,
            };

            return this.View(partModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditPart(EditPartFormModel part)
        {
            var category = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);

            var partToUpdate = this.data.Parts.FirstOrDefault(p => p.Id == part.Id);


            partToUpdate.Name = part.Name;
            partToUpdate.ImageUrl = part.ImageUrl;
            partToUpdate.Price = part.Price;
            partToUpdate.Quantity = part.Quantity;
            partToUpdate.Description = part.Description;
            partToUpdate.Category = category;

            this.data.SaveChanges();

            return this.RedirectToAction("UsersParts", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeletePart(string partId)
        {
            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            this.data.Parts.Remove(part);

            this.data.SaveChanges();

            return this.RedirectToAction("UsersParts", "Admins");
        }
    }
}
