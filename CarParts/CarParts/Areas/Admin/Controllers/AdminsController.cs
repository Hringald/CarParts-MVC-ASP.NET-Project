namespace CarParts.Areas.Admin.Controllers
{
    using CarParts.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using CarParts.Services.Admins;
    using CarParts.Services.Models;
    using CarParts.Services.Parts;
    using CarParts.Models.Parts;
    using CarParts.Services.Makes;
    using static WebConstants.Cache;
    using static WebConstants;
    using Microsoft.Extensions.Caching.Memory;
    using System.Collections.Generic;
    using System;
    using CarParts.Areas.Admin.Views.Models;

    public class AdminsController : Controller
    {
        private readonly IAdminsService admins;
        private readonly IModelsService models;
        private readonly IPartsService parts;
        private readonly IMakesService makes;
        public AdminsController(IAdminsService admins, IModelsService models, IPartsService parts, IMakesService makes)
        {
            this.admins = admins;
            this.models = models;
            this.parts = parts;
            this.makes = makes;
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

            this.TempData[GlobalMessageKey] = "Thank you for becoming admin! :)";

            return this.Redirect("/");
        }
        [Authorize]
        public IActionResult AddMake()
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddMake(AddMakeFormModel makeModel/*, IFormFile makeImage*/)
        {
            var adminId = this.admins.GetAdminId(this.User.GetId());

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
            if (this.makes.MakeExists(makeModel))
            {
                this.ModelState.AddModelError(nameof(makeModel.Name), "Make already exists.");
            }

            if (!ModelState.IsValid)
            {
                return this.View(makeModel);
            }

            this.makes.AddMake(makeModel, adminId);

            this.TempData[GlobalMessageKey] = "Make Added Successfully";

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult AddModel()
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var makes = this.models.GetMakes();


            return View(new AddModelFormModel
            {
                Makes = makes
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddModel(AddModelFormModel carModel)
        {
            var adminId = this.admins.GetAdminId(this.User.GetId());

            if (carModel.MakeId == null)
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrEmpty(adminId))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            if (!this.models.IsMakeValid(carModel))
            {
                this.ModelState.AddModelError(nameof(carModel.MakeId), "Make is invalid.");
            }


            if (this.models.DoesModelExist(carModel))
            {
                this.ModelState.AddModelError(nameof(carModel.Name), "This model already exists.");
            }

            if (!ModelState.IsValid)
            {
                carModel.Makes = this.models.GetMakes();

                return this.View(carModel);
            }



            this.models.AddModel(carModel, adminId);

            this.TempData[GlobalMessageKey] = "Model Added Successfully";

            return this.Redirect("/");
        }
        [Authorize]
        public IActionResult EditMakes()
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var makes = this.models.GetMakes();

            return this.View(makes);
        }
        [Authorize]
        public IActionResult EditMake(string makeId)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var make = this.makes.GetMakeById(makeId);

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

            this.makes.EditMake(makeModel, this.admins.GetAdminId(this.User.GetId()));

            this.TempData[GlobalMessageKey] = "Make edited Successfully";

            return RedirectToAction("EditMakes", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteMake(string makeId)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            this.makes.DeleteMake(makeId);

            this.TempData[GlobalMessageKey] = "Make Deleted Successfully";

            return RedirectToAction("EditMakes", "Admins");
        }

        [Authorize]
        public IActionResult EditModels()
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var models = this.models.GetEditModelInfo();

            return this.View(models);
        }
        [Authorize]
        public IActionResult EditModel(string modelId)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var makes = this.models.GetMakes();

            var model = this.models.GetModelById(modelId);

            var modelModel = new EditModelFormModel
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                MakeId = model.MakeId,
                Name = model.Name,
                Makes = makes
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

            var make = this.makes.GetMakeById(modelModel.MakeId);

            if (!this.parts.isMakeValid(make.Name))
            {
                this.ModelState.AddModelError(nameof(modelModel.MakeId), "Make is invalid.");
            }

            if (!ModelState.IsValid)
            {
                modelModel.Makes = this.models.GetMakes();

                return this.View(modelModel);
            }

            this.models.EditModel(modelModel, this.admins.GetAdminId(this.User.GetId()));

            this.TempData[GlobalMessageKey] = "Model Edited Successfully";

            return this.RedirectToAction("EditModels", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteModel(string modelId)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            this.models.DeleteModel(modelId);

            this.TempData[GlobalMessageKey] = "Model Deleted Successfully";

            return this.RedirectToAction("EditModels", "Admins");
        }
        [Authorize]
        public IActionResult UsersParts()
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var users = this.admins.GetUsersInfo();

            return this.View(users);
        }
        [Authorize]
        public IActionResult EditParts(string userId)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }


            var user = this.admins.GetUserById(userId);

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
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            var partModel = this.parts.GetEditPartInfo(partId);

            return this.View(partModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditPart(EditPartFormModel part)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            this.parts.EditPart(part);

            this.TempData[GlobalMessageKey] = "Part Edited Successfully";

            return this.RedirectToAction("UsersParts", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeletePart(string partId)
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            this.parts.Delete(partId);

            this.TempData[GlobalMessageKey] = "Part Deleted Successfully";

            return this.RedirectToAction("UsersParts", "Admins");
        }
    }
}
