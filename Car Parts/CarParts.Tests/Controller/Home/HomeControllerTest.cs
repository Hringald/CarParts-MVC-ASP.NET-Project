namespace CarParts.Tests.Controller
{
    using Car_Parts.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Xunit;
    public class HomeControllerTest
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arange
            var homeController = new HomeController(null);
            //Act
            var result = homeController.Error();
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }
    }
}
