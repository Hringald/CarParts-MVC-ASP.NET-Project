namespace CarParts.Controllers
{
    using CarParts.Infrastructure;
    using CarParts.Models.Parts;
    using CarParts.Services.Models;
    using CarParts.Services.Shop;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class ShopController : Controller
    {
        private readonly IShopService shop;
        private readonly IModelsService models;
        public ShopController(IShopService shop,IModelsService models)
        {
            this.shop = shop;
            this.models = models;
        }

        [Authorize]
        public IActionResult Models(string make)
        {
            ViewBag.Name = make;

            var modelsModel = this.models.GetModels(make);

            return this.View(modelsModel);
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
