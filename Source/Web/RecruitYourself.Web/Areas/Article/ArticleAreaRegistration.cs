namespace RecruitYourself.Web.Areas.Article
{
    using System.Web.Mvc;

    public class ArticleAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Article";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "ArticleById",
                url: "Article/AllArticles/ById/{id}",
                defaults: new { controller = "AllArticles", action = "ById", id = UrlParameter.Optional },
                namespaces: new[] { "RecruitYourself.Web.Areas.Article.Controllers" });

            context.MapRoute(
                name: "Article",
                url: "Article/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "RecruitYourself.Web.Areas.Article.Controllers" });
        }
    }
}
