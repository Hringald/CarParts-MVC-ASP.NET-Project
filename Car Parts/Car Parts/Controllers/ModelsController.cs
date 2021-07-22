namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ModelsController : Controller
    {
        private readonly CarPartsDbContext data;
        public ModelsController(CarPartsDbContext data)
        {
            this.data = data;
        }
        [Authorize]
        public IActionResult Models(string make)
        {
            ViewBag.Name = make;

            var modelsModel = this.data.Models.Where(m => m.Make.Name == make)
                .Select(m => new PartCategoryViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                }).ToList();

            return this.View(modelsModel);
        }

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
                AdminId = adminId
            };

            make.Models.Add(modelModel);
            this.data.Models.Add(modelModel);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
        //
        private ICollection<PartCategoryViewModel> GetPartModelMakes()
 =>
     this.data
         .Makes
         .Select(p => new PartCategoryViewModel
         {
             Id = p.Id,
             Name = p.Name,
         }).ToList();
        //
        private bool UserIsAdmin() => this.data.Admins
              .Any(a => a.UserId == this.User.GetId());
    }
}
