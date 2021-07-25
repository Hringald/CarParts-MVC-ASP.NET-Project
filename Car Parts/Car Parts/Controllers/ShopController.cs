namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ShopController : Controller
    {
        private readonly CarPartsDbContext data;
        public ShopController(CarPartsDbContext data)
        {
            this.data = data;
        }

        //Categories
        [Authorize]
        public IActionResult Categories(string make, string model)
        {
            ViewBag.Model = model;
            ViewBag.Make = make;
            var categories = this.data.Categories
                 .Select(c => new PartCategoryViewModel
                 {
                     Id = c.Id,
                     Name = c.Name,
                     ImageUrl = c.ImageUrl
                 }).ToList();

            return View(categories);
        }
        //
        //ShopPage
        [Authorize]
        public IActionResult ShopPage([FromQuery] AllPartsViewModel query)
        {
            var partQuery = this.data.Parts.AsQueryable();

            var totalParts = this.data.Parts
            .Where(p => p.Model.Name == query.Model && p.Make.Name == query.Make && p.Category.Name == query.Category)
            .Count();

            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                partQuery = partQuery.Where(p => p.Name.ToLower().Contains(query.SearchTerm.ToLower()));

                totalParts = this.data.Parts
                 .Where(p => p.Model.Name == query.Model && p.Make.Name == query.Make && p.Category.Name == query.Category)
                 .Where(p => p.Name.ToLower().Contains(query.SearchTerm.ToLower()))
                 .Count();
            }

            var parts = partQuery
                .Skip((query.CurrentPage - 1) * AllPartsViewModel.PartsPerPage)
                .Take(AllPartsViewModel.PartsPerPage)
                .Where(p => p.Model.Name == query.Model && p.Make.Name == query.Make && p.Category.Name == query.Category)
                .OrderByDescending(p => p.Id)
                .Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    MakeName = p.Make.Name,
                    ModelName = p.Model.Name,
                    Price = p.Price.ToString("F2"),
                    Quantity = p.Quantity,
                    IsSeller = p.SellerId == this.User.GetId()? true:false
                }).ToList();

            var partsModel = new AllPartsViewModel
            {
                Parts = parts,
                Make = query.Make,
                Model = query.Model,
                Category = query.Category,
                TotalParts = totalParts,
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage
            };



            return View(partsModel);
        }
        //
    }
}
