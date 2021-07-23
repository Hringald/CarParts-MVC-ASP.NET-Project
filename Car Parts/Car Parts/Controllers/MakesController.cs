namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Infrastructure;
    using Car_Parts.Models;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class MakesController : Controller
    {
        private readonly CarPartsDbContext data;
        public MakesController(CarPartsDbContext data)
        {
            this.data = data;
        }

        //Add Make
        [Authorize]
        public IActionResult AddMake()
        {
            if (!this.UserIsAdmin())
            {
                return this.RedirectToAction((nameof(AdminsController.Become)), "Admins");
            }
            return this.View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AddMake(AddMakeFormModel make/*, IFormFile makeImage*/)
        {
            var adminId = this.data.Admins
                .Where(a => a.UserId == this.User.GetId())
                .Select(d => d.Id)
                .FirstOrDefault();

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
                ImageUrl = make.ImageUrl,
                AdminId = adminId,      
            };

            this.data.Makes.Add(makeModel);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
        //
        //IsAdmin
        private bool UserIsAdmin() => this.data.Admins
                .Any(a => a.UserId == this.User.GetId());
    }
}
