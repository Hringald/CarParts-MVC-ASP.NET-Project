namespace CarParts.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using Xunit;
    using CarParts.Areas.Admin.Views.Models;
    using CarParts.Areas.Admin.Controllers;
    using CarParts.Models.Parts;

    public class AdminControllerTest
    {
        [Fact]
        public void PostBecomeRouteShouldBeMapped()
    => MyRouting
         .Configuration()
         .ShouldMap(request => request
           .WithPath("/Admins/Become")
           .WithMethod(HttpMethod.Post))
           .To<AdminsController>(c => c.Become(With.Any<AddAdminFormModel>()));

        [Fact]
        public void GetBecomeRouteShouldBeMapped()
    => MyRouting
         .Configuration()
         .ShouldMap(request => request
          .WithPath("/Admins/Become")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.Become());

        [Fact]
        public void PostAddMakeRouteShouldBeMapped()
    => MyRouting
         .Configuration()
         .ShouldMap(request => request
           .WithPath("/Admins/AddMake")
           .WithMethod(HttpMethod.Post))
           .To<AdminsController>(c => c.AddMake(With.Any<AddMakeFormModel>()));

        [Fact]
        public void GetAddMakeRouteShouldBeMapped()
    => MyRouting
         .Configuration()
         .ShouldMap(request => request
          .WithPath("/Admins/AddMake")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.AddMake());

        [Fact]
        public void PostAddModelRouteShouldBeMapped()
       => MyRouting
         .Configuration()
         .ShouldMap(request => request
           .WithPath("/Admins/AddModel")
           .WithMethod(HttpMethod.Post))
           .To<AdminsController>(c => c.AddModel(With.Any<AddModelFormModel>()));

        [Fact]
        public void GetAddModelRouteShouldBeMapped()
       => MyRouting
        .Configuration()
        .ShouldMap(request => request
          .WithPath("/Admins/AddModel")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.AddModel());

        [Fact]
        public void GetEditMakesRouteShouldBeMapped()
       => MyRouting
        .Configuration()
        .ShouldMap(request => request
          .WithPath("/Admins/EditMakes")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.EditMakes());

        [Fact]
        public void GetEditMakeRouteShouldBeMapped()
       => MyRouting
        .Configuration()
        .ShouldMap(request => request
          .WithPath("/Admins/EditMake")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.EditMake(With.Any<string>()));

        [Fact]
        public void GetEditModelsRouteShouldBeMapped()
       => MyRouting
        .Configuration()
        .ShouldMap(request => request
          .WithPath("/Admins/EditModels")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.EditModels());
      
        [Fact]
        public void GetEditModelRouteShouldBeMapped()
       => MyRouting
        .Configuration()
        .ShouldMap(request => request
          .WithPath("/Admins/EditModel")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.EditModel(With.Any<string>()));


        [Fact]
        public void PostEditMakeRouteShouldBeMapped()
    => MyRouting
         .Configuration()
         .ShouldMap(request => request
           .WithPath("/Admins/EditMake")
           .WithMethod(HttpMethod.Post))
           .To<AdminsController>(c => c.EditMake(With.Any<EditMakeFormModel>()));

        [Fact]
        public void GetDeleteMakeRouteShouldBeMapped()
    => MyRouting
        .Configuration()
         .ShouldMap(request => request
           .WithPath("/Admins/DeleteMake")
           .WithMethod(HttpMethod.Get))
           .To<AdminsController>(c => c.DeleteMake(With.Any<string>()));

        [Fact]
        public void PostEditModelRouteShouldBeMapped()
     => MyRouting
         .Configuration()
         .ShouldMap(request => request
           .WithPath("/Admins/EditModel")
           .WithMethod(HttpMethod.Post))
           .To<AdminsController>(c => c.EditModel(With.Any<EditModelFormModel>()));

        [Fact]
        public void GetDeleteModelRouteShouldBeMapped()
     => MyRouting
         .Configuration()
          .ShouldMap(request => request
          .WithPath("/Admins/DeleteModel")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.DeleteModel(With.Any<string>()));

        [Fact]
        public void GetUsersPartsRouteShouldBeMapped()
     => MyRouting
      .Configuration()
      .ShouldMap(request => request
        .WithPath("/Admins/UsersParts")
        .WithMethod(HttpMethod.Get))
        .To<AdminsController>(c => c.UsersParts());

        [Fact]
        public void GetEditPartsRouteShouldBeMapped()
     => MyRouting
     .Configuration()
     .ShouldMap(request => request
       .WithPath("/Admins/EditParts")
       .WithMethod(HttpMethod.Get))
       .To<AdminsController>(c => c.EditParts(With.Any<string>()));

        [Fact]
        public void GetEditPartRouteShouldBeMapped()
     => MyRouting
         .Configuration()
          .ShouldMap(request => request
          .WithPath("/Admins/EditPart")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.EditPart(With.Any<string>()));

        
        [Fact]
        public void PostEditPartRouteShouldBeMapped()
     => MyRouting
        .Configuration()
         .ShouldMap(request => request
         .WithPath("/Admins/EditPart")
         .WithMethod(HttpMethod.Post))
         .To<AdminsController>(c => c.EditPart(With.Any<EditPartFormModel>()));
        
        [Fact]
        public void GetDeletePartRouteShouldBeMapped()
     => MyRouting
         .Configuration()
          .ShouldMap(request => request
          .WithPath("/Admins/DeletePart")
          .WithMethod(HttpMethod.Get))
          .To<AdminsController>(c => c.DeletePart(With.Any<string>()));
    }
}
