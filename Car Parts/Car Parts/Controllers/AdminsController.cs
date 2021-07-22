namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Admins;
    using Car_Parts.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class AdminsController : Controller
    {
        private readonly CarPartsDbContext data;
        public AdminsController(CarPartsDbContext data)
        {
            this.data = data;
        }
        [Authorize]
        public IActionResult Become() => this.View();

        [HttpPost]
        [Authorize]
        public IActionResult Become(AddAdminFormModel admin)
        {
            if (this.data.Admins.Any(a => a.UserId == this.User.GetId()))
            {
                this.ModelState.AddModelError(nameof(admin.Name), "User is already admin.");
            }

            var userIsAlreadyAdmin = this.data
                .Admins
                .Any(a => a.UserId == this.User.GetId());

            if (!ModelState.IsValid)
            {
                return View(admin);
            }

            var adminData = new Admin
            {
                Name = admin.Name,
                UserId = this.User.GetId()
            };

            this.data.Admins.Add(adminData);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
    }
}
