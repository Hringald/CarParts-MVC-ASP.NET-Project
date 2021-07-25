namespace Car_Parts.Controllers
{
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Admins;
    using Car_Parts.Services.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ModelsController : Controller
    {
        private readonly IModelsService models;
        private readonly IAdminsService admins;

        public ModelsController(IModelsService models, IAdminsService admins)
        {
            this.models = models;
            this.admins = admins;
        }

        [Authorize]
        public IActionResult Models(string make)
        {
            ViewBag.Name = make;

            var modelsModel = this.models.GetModels(make);

            return this.View(modelsModel);
        }

        [Authorize]
        public IActionResult AddModel()
        {
            if (!this.admins.IsAdmin(this.User.GetId()))
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }

            return View(new AddModelFormModel
            {
                Makes = this.models.GetMakes()
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

            return this.Redirect("/");
        }
    }
}
