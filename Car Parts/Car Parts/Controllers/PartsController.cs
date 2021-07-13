using Car_Parts.Data;
using Car_Parts.Data.Models;
using Car_Parts.Models;
using Car_Parts.Models.Parts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

            var partModel = new Part
            {
                Name = part.Name,
                ImageUrl = part.ImageUrl,
                Category = category,
                Make = make,
                Model = model,
                Description = part.Description,
                Quantity = part.Quantity,
                Price = part.Price

            };

            this.data.Parts.Add(partModel);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        //Add Make
        public IActionResult AddMake()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult AddMake(AddMakeFormModel make)
        {
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
                ImageUrl = make.ImageUrl
            };

            this.data.Makes.Add(makeModel);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
        //
        //Add Model --------------------------------------------
        public IActionResult AddModel()
        {
            return View(new AddModelFormModel
            {
                Makes = this.GetPartModelMakes()
            });
        }
        [HttpPost]
        public IActionResult AddModel(AddModelFormModel carModel)
        {
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
                Make = make
            };

            make.Models.Add(modelModel);
            this.data.Models.Add(modelModel);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
        //private Methods
        private ICollection<PartMakeViewModel> GetPartMakes()
        =>
            this.data
                .Makes
                .Select(p => new PartMakeViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();

        private ICollection<PartModelViewModel> GetPartModelMakes()
        =>
            this.data
                .Makes
                .Select(p => new PartModelViewModel
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

        private ICollection<PartModelViewModel> GetPartModels()
 =>
     this.data
         .Models
         .Select(p => new PartModelViewModel
         {
             Id = p.Id,
             Name = p.Name
         }).ToList();

    }
}
