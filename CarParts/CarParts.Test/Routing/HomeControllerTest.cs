namespace CarParts.Test.Routing
{
    using MyTested.AspNetCore.Mvc;
    using CarParts.Controllers;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
          => MyRouting
              .Configuration()
              .ShouldMap("/")
              .To<HomeController>(c => c.Index());

        [Fact]
        public void ErrorRouteShouldBeMapped()
            => MyRouting
                .Configuration()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error());
    }
}