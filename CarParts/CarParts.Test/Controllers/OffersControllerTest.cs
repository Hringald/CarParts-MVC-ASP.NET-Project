namespace CarParts.Test.Controllers
{
    using CarParts.Controllers;
    using CarParts.Data.Models;
    using CarParts.Models.Offers;
    using FluentAssertions;
    using MyTested.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Xunit;
    public class OffersControllerTest
    {
        [Fact]
        public void MyOffersShouldReturnCorrectViewWithModel()
    => MyController<OffersController>
                  .Instance()
     .WithData(data => data
     .WithEntities(entities => entities.AddRange(
       new ApplicationUser { Id = "TestId", UserName = "TestUser" },
       new Part { Id = "PartTestId"},
       new Offer {Id="OfferTestId", SellerId = "TestId",PartId= "PartTestId" }
       )))
     .WithUser("TestUser")
     .Calling(c => c.MyOffers())
             .ShouldReturn()
             .View(view => view
                 .WithModelOfType<List<OffersViewModel>>()
                 .Passing(model => model.Should().HaveCount(1)));

        [Fact]
        public void InfoShouldReturnCorrectViewWithModel()
    => MyController<OffersController>
                 .Instance()
    .WithData(data => data
    .WithEntities(entities => entities.AddRange(
        new ApplicationUser { Id = "TestId", UserName = "TestUser" },
        new Make { Id = "MakeTestId" },
        new Model { Id = "ModelTestId" },
        new Category { Id = "CategoryTestId" },
        new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" },
        new Offer { Id = "OfferTestId", SellerId = "TestId", PartId = "PartTestId" }
      )))
    .WithUser("TestUser")
    .Calling(c => c.Info("OfferTestId"))
            .ShouldReturn()
            .View(view => view
                 .WithModelOfType<OfferInfoViewModel>());

    }
}
