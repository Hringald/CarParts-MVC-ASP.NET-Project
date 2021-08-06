namespace Car_Parts.Tests.Controllers.Home
{
    using Car_Parts;
    using Microsoft.AspNetCore.Mvc.Testing;
    using System.Threading.Tasks;
    using Xunit;

    public class HomeControllerSystemTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public HomeControllerSystemTest(WebApplicationFactory<Startup> factory)
        => this.factory = factory;

        [Fact]
        public async Task IndexShouldReturnCorrectStatusCode()
        {
            //Arange
            var client = this.factory.CreateClient();
            //Act
            var result = await client.GetAsync("/");
            //Arange
            Assert.True(result.IsSuccessStatusCode);
        }
    }
}