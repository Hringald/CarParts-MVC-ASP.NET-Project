namespace Car_Parts.Controllers
{
    using Car_Parts.Models.Admins;
    using Car_Parts.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Car_Parts.Services.Admins;

    public class AdminsController : Controller
    {
        private readonly IAdminsService admins;
        public AdminsController(IAdminsService admins)
        {
            this.admins = admins;
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
    }
}
