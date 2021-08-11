namespace CarParts.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using CarParts.Controllers;
    using Xunit;

    public class OfferControllerTest
    {
        [Fact]
        public void GetMyOffersRouteShouldBeMapped()
        => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Offers/MyOffers")
            .WithMethod(HttpMethod.Get))
            .To<OffersController>(c => c.MyOffers());
      
        [Fact]
        public void GetInfoRouteShouldBeMapped()
        => MyRouting
          .Configuration()
          .ShouldMap(request => request
            .WithPath("/Offers/Info")
            .WithMethod(HttpMethod.Get))
            .To<OffersController>(c => c.Info(With.Any<string>()));
        [Fact]
        public void GetSellRouteShouldBeMapped()
       => MyRouting
         .Configuration()
         .ShouldMap(request => request
           .WithPath("/Offers/Sell")
           .WithMethod(HttpMethod.Get))
           .To<OffersController>(c => c.Sell(With.Any<string>(), With.Any<string>()));

        [Fact]
        public void GetDeclineRouteShouldBeMapped()
             => MyRouting
           .Configuration()
           .ShouldMap(request => request
           .WithPath("/Offers/Decline")
           .WithMethod(HttpMethod.Get))
           .To<OffersController>(c => c.Decline(With.Any<string>()));
    }
}