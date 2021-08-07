namespace Car_Parts.Test.Controller
{
    using Car_Parts.Controllers;
    using Car_Parts.Models.Parts;
    using MyTested.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using Xunit;
    using static Car_Parts.Test.Data.Makes;
    using static Car_Parts.WebConstants.Cache;

    public class HomeControllerTest
    {
        [Fact]
        public void ReturnOkWithCorrectModelWhenCallingAuthenticatedIndexAction()
            => MyMvc                                                   // Start a test case.
                .Controller<HomeController>(instance => instance       // Arrange the controller under test.
                    .WithUser("TestUser")                              // Set an authenticated user to the request.
                    .WithData(TenMakes))                               // Populate the application DbContext.
                .Calling(c => c.Index())                               // Act - invoke the action under test.
                .ShouldReturn()                                        // Assert action behavior.
                .Ok(result => result                                   // Validate the action result type.
                    .WithModelOfType<List<PartCategoryViewModel>>()    // Check the response model type.
                    .Passing(model => model.Count == 10));             // Assert specific model properties. 

        [Fact]
        public void ErrorShouldReturnView()
                => MyController<HomeController>
                    .Instance()
                    .Calling(c => c.Error())
                    .ShouldReturn()
                    .View();
    }
}
