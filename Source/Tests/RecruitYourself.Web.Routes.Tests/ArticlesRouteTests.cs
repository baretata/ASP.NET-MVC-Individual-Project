namespace RecruitYourself.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class ArticlesRouteTests
    {
        [Test]
        public void ByIdRouteTest()
        {
            const string Url = "/Article/AllArticles/ById/MS4xMjMxMjMxMzEyMw==";
            var routeCollection = new RouteCollection();
            var areaRegistrationContext = new AreaRegistrationContext("Article", routeCollection);
            areaRegistrationContext.MapRoute(
                name: "ArticleById",
                url: "Article/AllArticles/ById/{id}",
                defaults: new {area="Article", controller = "AllArticles", action = "ById", id = UrlParameter.Optional });

            RouteAssert.HasRoute(routeCollection, Url, new { Area = "Article", Controller = "AllArticles", Action = "ById", Id = "MS4xMjMxMjMxMzEyMw==" });
        }
    }
}
