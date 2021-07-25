namespace Car_Parts.Controllers
{
    using Car_Parts.Infrastructure;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Shop;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ShopController : Controller
    {
        private readonly IShopService shop;
        public ShopController(IShopService shop)
        {
            this.shop = shop;
        }

        [Authorize]
        public IActionResult Categories(string make, string model)
        {
            ViewBag.Model = model;
            ViewBag.Make = make;

            var categories = this.shop.GetCategories();

            return View(categories);
        }

        [Authorize]
        public IActionResult ShopPage([FromQuery] AllPartsViewModel query)
        {

          var partsModel = this.shop.ShopPageRender(query,this.User.GetId());

            return View(partsModel);
        }
    }
}
