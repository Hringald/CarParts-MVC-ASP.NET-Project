namespace CarParts.Test.Routing
{
    using CarParts.Controllers;
    using CarParts.Models.Parts;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ShopControllerTest
    {
        [Fact]
        public void GetModelsRouteShouldBeMapped()
        => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Shop/Models")
            .WithMethod(HttpMethod.Get))
            .To<ShopController>(c => c.Models(With.Any<string>()));

        [Fact]
        public void GetCategoriesRouteShouldBeMapped()
        => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Shop/Categories")
            .WithMethod(HttpMethod.Get))
            .To<ShopController>(c => c.Categories(With.Any<string>(), With.Any<string>()));

        [Fact]
        public void GetShopPageRouteShouldBeMapped()
        => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Shop/ShopPage")
            .WithMethod(HttpMethod.Get))
            .To<ShopController>(c => c.ShopPage(With.Any<AllPartsViewModel>()));
    }
}
