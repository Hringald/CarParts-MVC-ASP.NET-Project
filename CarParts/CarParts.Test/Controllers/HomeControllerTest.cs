namespace CarParts.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using CarParts.Controllers;
    using Xunit;
    using System.Collections.Generic;
    using CarParts.Models.Parts;
    using FluentAssertions;
    using static CarParts.Test.Data.Makes;
    using static WebConstants.Cache;
    using System;

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
                    .WithModelOfType<List<PartCategoryViewModel>>()
                    .Passing(model => model.Should().HaveCount(10)));

        [Fact]
        public void ErrorShouldReturnView()
          => MyController<HomeController>
              .Instance()
              .Calling(c => c.Error())
              .ShouldReturn()
              .View();
    }
}