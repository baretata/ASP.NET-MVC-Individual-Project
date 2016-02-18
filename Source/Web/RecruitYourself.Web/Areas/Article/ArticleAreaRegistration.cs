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
                name: "Article",
                url: "Article/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
