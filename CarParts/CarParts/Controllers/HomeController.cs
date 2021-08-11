namespace CarParts.Controllers
{
    using CarParts.Models.Parts;
    using CarParts.Services.Home;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic;
    using static WebConstants.Cache;
    public class HomeController : Controller
    {
        private readonly IHomeService home;
        private readonly IMemoryCache cache;
        public HomeController(IHomeService home, IMemoryCache cache)
        {
            this.home = home;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

            var makes = this.cache.Get<ICollection<PartCategoryViewModel>>(getMakesCacheKey);

            if (makes == null)
            {
                makes = this.home.GetMakes();

                this.cache.Set(getMakesCacheKey, makes, cacheOptions);
            }

            return View(makes);
        }

        public IActionResult Error() => this.View();
    }
}
