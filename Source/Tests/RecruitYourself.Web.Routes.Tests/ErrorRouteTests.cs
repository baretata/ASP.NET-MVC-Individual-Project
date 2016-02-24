namespace RecruitYourself.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;
    using NUnit.Framework;

    using RecruitYourself.Web.Controllers;

    [TestFixture]
    public class ErrorRouteTests
    {
        [Test]
        public void PageNotFoundRouteTest()
        {
            const string Url = "/Error/PageNotFound";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection
                .ShouldMap(Url)
                .To<ErrorController>(c => c.PageNotFound());
        }
    }
}
