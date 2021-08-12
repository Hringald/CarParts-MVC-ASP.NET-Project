namespace CarParts.Controllers
{
    using CarParts.Services.Parts;
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : Controller
    {
        private readonly IPartsService parts;
        public HomeController(IPartsService parts)
        {
            this.parts = parts;
        }

        public IActionResult Index()
        {
            var makes = this.parts.GetMakes();

            return View(makes);
        }

        public IActionResult Error() => this.View();
    }
}
