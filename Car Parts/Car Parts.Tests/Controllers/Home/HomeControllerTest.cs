namespace Car_Parts.Tests.Controllers.Home
{
    using Car_Parts.Controllers;
    using Car_Parts.Models.Parts;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using Xunit;
    using static Data.Makes;
    using static WebConstants.Cache;
    public class HomeControllerTest
    {
        [Fact]
        public void IndexShouldReturnCorrectViewWithModel()
          => MyController<HomeController>
              .Instance(controller => controller
                  .WithData(TenMakes))
              .Calling(c => c.Index())
              .ShouldHave()
              .MemoryCache(cache => cache
                  .ContainingEntry(entry => entry
                      .WithKey(getMakesCacheKey)
                      .WithAbsoluteExpirationRelativeToNow(TimeSpan.FromMinutes(15))
                      .WithValueOfType<List<PartCategoryViewModel>>()))
              .AndAlso()
              .ShouldReturn()
              .View(view => view
                  .WithModelOfType<List<PartCategoryViewModel>>());

        [Fact]
        public void ErrorShouldReturnView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Error())
                .ShouldReturn()
                .View();
    }
}
