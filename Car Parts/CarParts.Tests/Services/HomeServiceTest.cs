namespace Car_Parts.Tests.Services
{
    using Car_Parts.Controllers;
    using Car_Parts.Data.Models;
    using Car_Parts.Models.Parts;
    using Car_Parts.Services.Admins;
    using Car_Parts.Tests.Mocks;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Xunit;
    public class HomeServiceTest
    {
        public void GetMakesReturnsMakes()
        {
            //Arange
            using var data = DatabaseMock.Instance;
            data.Makes.Add(new Make { Id = "Test", Name = "TestName" });

            var expectedResult = new List<PartCategoryViewModel>();

            var homeService = new HomeService(data);

            var homeController = new HomeController(homeService);
            //Act
            var result = homeController.Index();
            //Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = viewResult.Model;

            var indexViewModel = Assert.IsType<List<PartCategoryViewModel>>(model);

            Assert.NotNull(homeService.GetMakes());
            Assert.Equal(expectedResult,homeService.GetMakes());
        }
    }
}
