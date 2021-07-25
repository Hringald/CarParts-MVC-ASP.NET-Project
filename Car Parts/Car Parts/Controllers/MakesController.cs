namespace Car_Parts.Controllers
{
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Admins;
    using Car_Parts.Services.Makes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MakesController : Controller
    {
        private readonly IAdminsService admins;
        private readonly IMakesService makes;
        public MakesController(IAdminsService admins, IMakesService makes)
        {
            this.admins = admins;
            this.makes = makes;
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

            return this.Redirect("/");
        }
    }
}
