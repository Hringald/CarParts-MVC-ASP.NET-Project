namespace CarParts.Test.Controllers
{
    using CarParts.Controllers;
    using CarParts.Data.Models;
    using CarParts.Models.Parts;
    using MyTested.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Xunit;
    using static Data.Makes;
    using FluentAssertions;
    using CarParts.Models.Offers;

    public class PartsControllerTest
    {

        [Fact]
        public void ChooseMakeShouldReturnCorrectViewWithModel()
           => MyController<PartsController>
               .Instance(controller => controller
                   .WithData(TenMakes))
               .Calling(c => c.ChooseMake())
               .ShouldReturn()
               .View(view => view
                   .WithModelOfType<List<PartCategoryViewModel>>()
                   .Passing(model => model.Should().HaveCount(10)));

        [Fact]
        public void EditModelShouldReturnCorrectViewWithModelIfUserIsAdmin()
          => MyController<PartsController>
          .Instance()
          .WithData(data => data
          .WithEntities(entities => entities.AddRange(
              new Make { Id = "MakeTestId",Name = "TestMakeName" },
              new Model { Id = "ModelTestId" },
              new Category { Id = "CategoryTestId" }
          )))
          .WithUser("TestUser")
          .Calling(c => c.AddPart("TestMakeName"))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AddPartFormModel>());

        [Fact]
        public void InfoShouldReturnCorrectViewWithModel()
        => MyController<PartsController>
            .Instance()
             .WithData(data => data
             .WithEntities(entities => entities.AddRange(
                 new ApplicationUser { Id = "TestId", UserName = "TestUser" },
                 new Make { Id = "MakeTestId" },
                 new Model { Id = "ModelTestId" },
                 new Category { Id = "CategoryTestId" },
                 new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" })))
             .WithUser("TestUser")
            .Calling(c => c.Info("PartTestId"))
            .ShouldReturn()
            .View(view => view
                .WithModelOfType<AddOfferFormModel>());

        [Fact]
        public void EditShouldReturnCorrectViewWithModel()
         => MyController<PartsController>
                  .Instance()
         .WithData(data => data
         .WithEntities(entities => entities.AddRange(
         new Make { Id = "MakeTestId" },
         new Model { Id = "ModelTestId" },
         new Category { Id = "CategoryTestId" },
         new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" })))
         .WithUser("TestUser")
         .Calling(c => c.Edit("PartTestId"))
             .ShouldReturn()
             .View(view => view
                  .WithModelOfType<EditPartFormModel>());
    }
}
