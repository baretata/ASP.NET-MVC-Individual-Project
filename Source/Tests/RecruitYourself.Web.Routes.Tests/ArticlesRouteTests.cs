namespace RecruitYourself.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using MvcRouteTester;
    using NUnit.Framework;

    using RecruitYourself.Web.Areas.Article.Controllers;

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
            //var expected = new { controller = "Home", action = "Index", id = 42 };
            //routeCollection
            //    .ShouldMap(Url)
            //    .To<AllArticlesController>(c => c.ById("MS4xMjMxMjMxMzEyMw=="));

            RouteAssert.HasRoute(routeCollection, Url, new { Area = "Article", Controller = "AllArticles", Action = "ById", Id = "MS4xMjMxMjMxMzEyMw==" });
        }
    }
}
