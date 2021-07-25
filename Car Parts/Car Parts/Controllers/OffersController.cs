namespace Car_Parts.Controllers
{
    using Car_Parts.Data;
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Offers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class OffersController : Controller
    {
        private readonly CarPartsDbContext data;
        public OffersController(CarPartsDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult MyOffers()
        {
            var offers = this.data.Offers.Where(o => o.SellerId == this.User.GetId());

            var offersModel = offers.Select(o => new OffersViewModel
            {
                Id = o.Id,
                PartName = o.Part.Name,
                BuyerName = o.Name,
                Price = o.Part.Price.ToString("f2"),
                Quantity = o.Part.Quantity
            }).ToList();

            return View(offersModel);
        }

        [Authorize]
        public IActionResult Info(string offerId)
        {
            var offer = this.data.Offers.FirstOrDefault(o => o.Id == offerId);

            var part = this.data.Parts.FirstOrDefault(p => p.Id == offer.PartId);

            var partCategory = this.data.Categories.FirstOrDefault(c => c.Id == part.CategoryId);
            var partMake = this.data.Makes.FirstOrDefault(m => m.Id == part.MakeId);
            var partModel = this.data.Models.FirstOrDefault(m => m.Id == part.ModelId);

            var infoModel = new OfferInfoViewModel
            {
                Id = part.Id,
                OfferId = offer.Id,
                Address = offer.Address,
                BuyerName = offer.Name,
                City = offer.City,
                Email = offer.Email,
                Zip = offer.ZipCode.ToString(),
                Phone = offer.Phone,
                CategoryName = partCategory.Name,
                ImageUrl = part.ImageUrl,
                Description = part.Description,
                MakeName = partMake.Name,
                ModelName = partModel.Name,
                Price = part.Price.ToString("f2"),
                Name = part.Name,
                Quantity = part.Quantity,
            };



            return View(infoModel);

        }
        [HttpGet]
        [Authorize] 
        public IActionResult Sell(string partId, string offerId)
        {
            var offer = this.data.Offers.FirstOrDefault(o => o.Id == offerId);
            var part = this.data.Parts.FirstOrDefault(p => p.Id == partId);

            if (part.Quantity - 1 <= 0)
            {
                this.data.Remove(part);
            }
            else
            {
                part.Quantity -= 1;
            }

            this.data.Offers.Remove(offer);
            this.data.SaveChanges();

            return this.RedirectToAction("MyOffers", "Offers");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Decline(string offerId)
        {
            var offer = this.data.Offers.FirstOrDefault(o => o.Id == offerId);
            this.data.Offers.Remove(offer);
            this.data.SaveChanges();

            return this.RedirectToAction("MyOffers", "Offers");
        }

    }
}
