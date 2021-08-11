namespace CarParts.Test.Controllers
{
    using CarParts.Controllers;
    using CarParts.Data.Models;
    using CarParts.Models.Parts;
    using MyTested.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Xunit;
    public class ShopControllerTest
    {
        [Fact]
        public void ModelsShouldReturnCorrectViewWithModel()
         => MyController<ShopController>
                  .Instance()
         .WithData(data => data
         .WithEntities(entities => entities.AddRange(
         new Make { Id = "MakeTestId" },
         new Model { Id = "ModelTestId" },
         new Category { Id = "CategoryTestId" },
         new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" })))
         .WithUser("TestUser")
         .Calling(c => c.Models("MakeTestId"))
             .ShouldReturn()
             .View(view => view
                  .WithModelOfType<List<PartCategoryViewModel>>());

        [Fact]
        public void CategoriesShouldReturnCorrectViewWithModel()
         => MyController<ShopController>
                  .Instance()
         .WithData(data => data
         .WithEntities(entities => entities.AddRange(
         new Make { Id = "MakeTestId", Name="TestMakeName" },
         new Model { Id = "ModelTestId", Name = "TestModelName" },
         new Category { Id = "CategoryTestId" },
         new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" })))
         .WithUser("TestUser")
         .Calling(c => c.Categories("TestMakeName","TestModelName"))
             .ShouldReturn()
             .View(view => view
                  .WithModelOfType<List<PartCategoryViewModel>>());

        [Fact]
        public void ShopPageShouldReturnCorrectViewWithModel()
         => MyController<ShopController>
                  .Instance()
         .WithData(data => data
         .WithEntities(entities => entities.AddRange(
         new Make { Id = "MakeTestId", Name = "TestMakeName" },s
         new Model { Id = "ModelTestId", Name = "TestModelName" },
         new Category { Id = "CategoryTestId" },
         new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" })))
         .WithUser("TestUser")
         .Calling(c => c.ShopPage(new AllPartsViewModel()))
             .ShouldReturn()
             .View(view => view
                  .WithModelOfType<AllPartsViewModel>());
    }
}
