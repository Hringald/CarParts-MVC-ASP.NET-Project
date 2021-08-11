namespace CarParts.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using CarParts.Controllers;
    using Xunit;
    using CarParts.Models.Parts;
    using CarParts.Models.Offers;

    public class PartsControllerTest
    {
        [Fact]
        public void GetChooseMakeRouteShouldBeMapped()
            => MyRouting
          .Configuration()
          .ShouldMap(request => request
          .WithPath("/Parts/ChooseMake")
          .WithMethod(HttpMethod.Get))
          .To<PartsController>(c => c.ChooseMake());

        [Fact]
        public void GetAddPartRouteShouldBeMapped()
           => MyRouting
         .Configuration()
         .ShouldMap(request => request
         .WithPath("/Parts/AddPart")
         .WithMethod(HttpMethod.Get))
         .To<PartsController>(c => c.AddPart(With.Any<string>()));
        /*
       [Fact]
       public void PostAddPartRouteShouldBeMapped()
              => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Parts/AddPart")
            .WithMethod(HttpMethod.Post))
            .To<PartsController>(c => c.AddPart(With.Any<AddPartFormModel>()));
        */

       [Fact]
       public void GetInfoRouteShouldBeMapped()
             => MyRouting
           .Configuration()
           .ShouldMap(request => request
           .WithPath("/Parts/Info")
           .WithMethod(HttpMethod.Get))
           .To<PartsController>(c => c.Info(With.Any<string>()));

       [Fact]
       public void PostInfoRouteShouldBeMapped()
              => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Parts/Info")
            .WithMethod(HttpMethod.Post))
            .To<PartsController>(c => c.Info(With.Any<AddOfferFormModel>()));

       [Fact]
       public void GetEditRouteShouldBeMapped()
              => MyRouting
            .Configuration()
            .ShouldMap(request => request
            .WithPath("/Parts/Edit")
            .WithMethod(HttpMethod.Get))
            .To<PartsController>(c => c.Edit(With.Any<string>()));
       /*
       [Fact]
       public void PostEditRouteShouldBeMapped()
            => MyRouting
          .Configuration()
          .ShouldMap(request => request
          .WithPath("/Parts/Edit")
          .WithMethod(HttpMethod.Post))
          .To<PartsController>(c => c.Edit(With.Any<EditPartFormModel>()));
       */

        [Fact]
        public void GetDeleteRouteShouldBeMapped()
          => MyRouting
        .Configuration()
        .ShouldMap(request => request
        .WithPath("/Parts/Delete")
        .WithMethod(HttpMethod.Get))
        .To<PartsController>(c => c.Delete(With.Any<string>()));

        [Fact]
        public void GetMyPartsRouteShouldBeMapped()
          => MyRouting
        .Configuration()
        .ShouldMap(request => request
        .WithPath("/Parts/MyParts")
        .WithMethod(HttpMethod.Get))
        .To<PartsController>(c => c.MyParts());
    }
}