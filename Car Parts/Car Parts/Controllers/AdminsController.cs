namespace Car_Parts.Controllers
{
    using Car_Parts.Models.Admins;
    using Car_Parts.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Car_Parts.Services.Admins;
    using Car_Parts.Services.Models;
    using Car_Parts.Services.Parts;
    using System.Linq;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Makes;

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

            return this.Redirect("/");
        }
        [Authorize]
        public IActionResult EditMakes()
        {
            var makes = this.parts.GetMakes();

            return this.View(makes);
        }
        [Authorize]
        public IActionResult EditMake(string makeId)
        {
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

            this.makes.EditMake(makeModel,this.admins.GetAdminId(this.User.GetId()));

            return RedirectToAction("EditMakes", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteMake(string makeId)
        {
            this.makes.DeleteMake(makeId);

            return RedirectToAction("EditMakes", "Admins");
        }

        [Authorize]
        public IActionResult EditModels()
        {
            var models = this.models.GetEditModelInfo();

            return this.View(models);
        }
        [Authorize]
        public IActionResult EditModel(string modelId)
        {
            var model = this.models.GetModelById(modelId);

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

            this.models.EditModel(modelModel,this.admins.GetAdminId(this.User.GetId()));

            return this.RedirectToAction("EditModels", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeleteModel(string modelId)
        {
            this.models.DeleteModel(modelId);

            return this.RedirectToAction("EditModels", "Admins");
        }
        [Authorize]
        public IActionResult UsersParts()
        {
            var users = this.admins.GetUsersInfo();

            return this.View(users);
        }
        [Authorize]
        public IActionResult EditParts(string userId)
        {
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
            var partModel = this.parts.GetEditPartInfo(partId);

            return this.View(partModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult EditPart(EditPartFormModel part)
        {
            this.parts.EditPart(part);

            return this.RedirectToAction("UsersParts", "Admins");
        }
        [HttpGet]
        [Authorize]
        public IActionResult DeletePart(string partId)
        {
            this.parts.Delete(partId);

            return this.RedirectToAction("UsersParts", "Admins");
        }
    }
}
