namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Models;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly CarPartsDbContext data;
        public HomeController(CarPartsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var makes = this.data.Makes
                .Select(m => new CategoryMakeModelView
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                }).ToList();



            return View(makes);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
