namespace Car_Parts.Controllers
{
    using Car_Parts.Infrastructure;
    using Car_Parts.Services.Offers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;
    public class OffersController : Controller
    {
        private readonly IOffersService offers;
        public OffersController(IOffersService offers)
        {
            this.offers = offers;
        }

        [Authorize]
        public IActionResult MyOffers()
        {
            var offersModel = this.offers.GetOffers(this.User.GetId());

            return View(offersModel);
        }

        [Authorize]
        public IActionResult Info(string offerId)
        {
            var infoModel = this.offers.GetOfferInfo(offerId);

            return View(infoModel);

        }
        [HttpGet]
        [Authorize] 
        public IActionResult Sell(string partId, string offerId)
        {
            this.offers.Sell(partId, offerId);

            this.TempData[GlobalMessageKey] = "Part Selled Successfully";

            return this.RedirectToAction("MyOffers", "Offers");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Decline(string offerId)
        {
            this.offers.Decline(offerId);

            this.TempData[GlobalMessageKey] = "Offer Declined";

            return this.RedirectToAction("MyOffers", "Offers");
        }

    }
}
