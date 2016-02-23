namespace RecruitYourself.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    using RecruitYourself.Web.Areas.Article.Controllers;

    [TestFixture]
    public class RegistrationRouteTests
    {
        [Test]
        public void RegisterVolunteerRouteTest()
        {
            const string Url = "/Account/Register/Volunteer";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection
                .ShouldMap(HttpMethod.Get, Url)
                .To<AccountController>(c => c.Register());
        }

        [Test]
        public void RegisterOrganizationRouteTest()
        {
            const string Url = "/Account/Register/Organization";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection
                .ShouldMap(HttpMethod.Get, Url)
                .To<AccountController>(c => c.Register());
        }
    }
}
