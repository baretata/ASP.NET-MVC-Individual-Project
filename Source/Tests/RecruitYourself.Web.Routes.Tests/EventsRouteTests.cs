namespace RecruitYourself.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using MvcRouteTester;
    using NUnit.Framework;
    
    [TestFixture]
    public class EventsRouteTests
    {
        [Test]
        public void EventByIdShouldMapCorrectlyRouteTest()
        {
            const string Url = "/Event/AllEvents/ById/MS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            var areaRegistrationContext = new AreaRegistrationContext("Event", routeCollection);
            areaRegistrationContext.MapRoute(
                name: "EventById",
                url: "Event/AllEvents/ById/{id}",
                defaults: new { area = "Event", controller = "AllEvents", action = "ById", id = UrlParameter.Optional });

            RouteAssert.HasRoute(routeCollection, Url, new { Area = "Event", Controller = "AllEvents", Action = "ById", Id = "MS4xMjMxMjMxMzEyMw==" });
        }
    }
}
