namespace CarParts.Test.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using CarParts.Areas.Admin.Controllers;
    using Xunit;
    using CarParts.Data.Models;
    using static WebConstants.Cache;
    using System;
    using CarParts.Models.Parts;
    using System.Collections.Generic;
    using CarParts.Areas.Admin.Views.Models;
    using FluentAssertions;
    using static Data.Parts;
    using CarParts.Test.Data;

    public class AdminsControllerTest
    {
        [Fact]
        public void BecomeShouldReturnCorrectViewWithModel()
            => MyController<AdminsController>
                .Instance()
                .Calling(c => c.Become())
                .ShouldReturn()
                .View();

        [Fact]
        public void AddMakeShouldReturnCorrectViewWithModelIfUserIsAdmin()
    => MyController<AdminsController>
        .Instance()
        .WithData(data => data
        .WithEntities(entities => entities.AddRange(
            new ApplicationUser { Id = "TestId", UserName = "TestUser" },
            new Admin { UserId = "TestId", Name = "TestName" })))
        .WithUser("TestUser")
        .Calling(c => c.AddMake())
        .ShouldReturn()
        .View();

        [Fact]
        public void AddMakeShouldReturnRedirectIfUserIsNotAdmin()
    => MyController<AdminsController>
        .Instance()
        .WithUser("TestUser")
        .Calling(c => c.AddMake())
        .ShouldReturn()
        .Redirect();

        [Fact]
        public void AddModelShouldReturnCorrectViewWithModelIfUserIsAdmin()
    => MyController<AdminsController>
      .Instance()
      .WithData(data => data
      .WithEntities(entities => entities.AddRange(
          new ApplicationUser { Id = "TestId", UserName = "TestUser" },
          new Admin { UserId = "TestId", Name = "TestName" })))
      .WithUser("TestUser")
      .Calling(c => c.AddModel())
      .ShouldHave()
                .MemoryCache(cache => cache
                    .ContainingEntry(entry => entry
                        .WithKey(getMakesCacheKey)
                        .WithAbsoluteExpirationRelativeToNow(TimeSpan.FromMinutes(15))
                        .WithValueOfType<List<PartCategoryViewModel>>()))
                .AndAlso()
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<AddModelFormModel>());

        [Fact]
        public void AddModelShouldReturnRedirectIfUserIsNotAdmin()
    => MyController<AdminsController>
      .Instance()
      .WithUser("TestUser")
      .Calling(c => c.AddModel())
      .ShouldReturn()
      .Redirect();

        [Fact]
        public void EditMakesShouldReturnCorrectViewWithModelIfUserIsAdmin()
    => MyController<AdminsController>
    .Instance()
    .WithData(data => data
    .WithEntities(entities => entities.AddRange(
      new ApplicationUser { Id = "TestId", UserName = "TestUser" },
      new Admin { UserId = "TestId", Name = "TestName" })))
    .WithUser("TestUser")
    .Calling(c => c.EditMakes())
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
        public void EditMakesShouldReturnRedirectIfUserIsNotAdmin()
    => MyController<AdminsController>
    .Instance()
    .WithUser("TestUser")
    .Calling(c => c.EditMakes())
    .ShouldReturn()
    .Redirect();

        [Fact]
        public void EditMakeShouldReturnCorrectViewWithModelIfUserIsAdmin()
    => MyController<AdminsController>
    .Instance()
    .WithData(data => data
    .WithEntities(entities => entities.AddRange(
      new ApplicationUser { Id = "TestId", UserName = "TestUser" },
      new Admin { UserId = "TestId", Name = "TestName" },
      new Make { Id = "TestId" }
      )))
    .WithUser("TestUser")
    .Calling(c => c.EditMake("TestId"))
            .ShouldReturn()
            .View(view => view
                .WithModelOfType<EditMakeFormModel>());

        [Fact]
        public void EditMakeShouldReturnRedirectIfUserIsNotAdmin()
    => MyController<AdminsController>
    .Instance()
    .WithUser("TestUser")
    .Calling(c => c.EditMake("TestId"))
    .ShouldReturn()
    .Redirect();

        [Fact]
        public void EditModelsShouldReturnCorrectViewWithModelIfUserIsAdmin()
    => MyController<AdminsController>
     .Instance()
     .WithData(data => data
     .WithEntities(entities => entities.AddRange(
         new ApplicationUser { Id = "TestId", UserName = "TestUser" },
         new Admin { UserId = "TestId", Name = "TestName" })))
     .WithUser("TestUser")
     .Calling(c => c.EditModels())
     .ShouldReturn()
     .View();

        [Fact]
        public void EditModelsShouldReturnRedirectIfUserIsNotAdmin()
    => MyController<AdminsController>
     .Instance()
     .WithUser("TestUser")
     .Calling(c => c.EditModels())
     .ShouldReturn()
     .Redirect();

        [Fact]
        public void EditModelShouldReturnCorrectViewWithModelIfUserIsAdmin()
     => MyController<AdminsController>
     .Instance()
     .WithData(data => data
     .WithEntities(entities => entities.AddRange(
       new ApplicationUser { Id = "TestId", UserName = "TestUser" },
       new Admin { UserId = "TestId", Name = "TestName" },
       new Model { Id = "TestId" }
       )))
     .WithUser("TestUser")
     .Calling(c => c.EditModel("TestId"))
     .ShouldHave()
             .MemoryCache(cache => cache
                 .ContainingEntry(entry => entry
                     .WithKey(getMakesCacheKey)
                     .WithAbsoluteExpirationRelativeToNow(TimeSpan.FromMinutes(15))
                     .WithValueOfType<List<PartCategoryViewModel>>()))
             .AndAlso()
             .ShouldReturn()
             .View(view => view
                 .WithModelOfType<EditModelFormModel>());

        [Fact]
        public void EditModelShouldReturnRedirectIfUserIsNotAdmin()
     => MyController<AdminsController>
     .Instance()
     .WithUser("TestUser")
     .Calling(c => c.EditModel("TestId"))
     .ShouldReturn()
     .Redirect();

        [Fact]
        public void UsersPartsShouldReturnCorrectViewWithModelIfUserIsAdmin()
     => MyController<AdminsController>
     .Instance()
     .WithData(data => data
     .WithEntities(entities => entities.AddRange(
      new ApplicationUser { Id = "TestId", UserName = "TestUser" },
      new ApplicationUser { Id = "TestId1", UserName = "TestUser1" },
      new Admin { UserId = "TestId", Name = "TestName" }
      )))
     .WithUser("TestUser")
     .Calling(c => c.UsersParts())
     .ShouldReturn()
          .View(view => view
          .WithModelOfType<List<UsersPartsViewModel>>()
          .Passing(model => model.Should().HaveCount(1)));

        [Fact]
        public void UsersPartsShouldReturnRedirectIfUserIsNotAdmin()
     => MyController<AdminsController>
      .Instance()
      .WithUser("TestUser")
      .Calling(c => c.UsersParts())
      .ShouldReturn()
      .Redirect();

        [Fact]
        public void EditPartsShouldReturnCorrectViewWithModelIfUserIsAdmin()
     => MyController<AdminsController>
     .Instance()
     .WithData(data => data
     .WithEntities(entities => entities.AddRange(
     new ApplicationUser { Id = "TestId", UserName = "TestUser" },
     new ApplicationUser { Id = "TestId1", UserName = "TestUser1" },
     new Admin { UserId = "TestId", Name = "TestName" }
     )))
     .WithUser("TestUser")
     .Calling(c => c.EditParts("TestId1"))
     .ShouldReturn()
       .View(view => view
       .WithModelOfType<EditPartsViewModel>());

        [Fact]
        public void EditPartsShouldReturnRedirectIfUserIsNotAdmin()
     => MyController<AdminsController>
      .Instance()
      .WithUser("TestUser")
      .Calling(c => c.EditParts("TestId"))
      .ShouldReturn()
      .Redirect();

        [Fact]
        public void EditPartShouldReturnCorrectViewWithModelIfUserIsAdmin()
     => MyController<AdminsController>
      .Instance()
      .WithData(data => data
      .WithEntities(entities => entities.AddRange(
        new ApplicationUser { Id = "TestId", UserName = "TestUser" },
        new Admin { UserId = "TestId", Name = "TestName" },
        new Make { Id = "MakeTestId" },
        new Model { Id = "ModelTestId" },
        new Category { Id = "CategoryTestId" },
        new Part { Id = "PartTestId", MakeId = "MakeTestId", ModelId = "ModelTestId", CategoryId = "CategoryTestId" }
        )))
      .WithUser("TestUser")
      .Calling(c => c.EditPart("PartTestId"))
            .ShouldReturn()
            .View(view => view
                .WithModelOfType<EditPartFormModel>());

        [Fact]
        public void EditPartShouldReturnRedirectIfUserIsNotAdmin()
     => MyController<AdminsController>
      .Instance()
      .WithUser("TestUser")
      .Calling(c => c.EditPart("TestId"))
      .ShouldReturn()
      .Redirect();
    }
}