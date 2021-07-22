namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Parts;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class OffersController : Controller
    {
        private readonly CarPartsDbContext data;
        public OffersController(CarPartsDbContext data)
        {
            this.data = data;
        }

        public IActionResult MyOffers()
        {
            var myOffers = this.data.Parts
                .Where(p => p.SellerId == this.User.GetId())
                .Select(p => new OffersViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                }).ToList();

            return View(myOffers);
        }
    }
}
