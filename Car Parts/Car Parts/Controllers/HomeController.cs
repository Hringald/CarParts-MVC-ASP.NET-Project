namespace Car_Parts.Controllers
{
    using Car_Parts.Services.Home;
    using Microsoft.AspNetCore.Mvc;


    public class HomeController : Controller
    {
        private readonly IHomeService home;
        public HomeController(IHomeService home)
        {
            this.home = home;
        }

        public IActionResult Index()
        {
            var makes = this.home.GetMakes();

            return View(makes);
        }
    }
}
