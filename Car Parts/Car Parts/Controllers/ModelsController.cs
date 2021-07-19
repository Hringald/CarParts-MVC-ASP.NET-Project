namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Models;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;

    public class ModelsController : Controller
    {
        private readonly CarPartsDbContext data;
        public ModelsController(CarPartsDbContext data)
        {
            this.data = data;
        }

        public IActionResult Models(string make)
        {
            ViewBag.Name = make;

            var modelsModel = this.data.Models.Where(m => m.Make.Name == make)
                .Select(m => new PartCategoryViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImageUrl = m.ImageUrl
                }).ToList();

            return this.View(modelsModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
