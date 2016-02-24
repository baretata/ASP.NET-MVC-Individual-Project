namespace RecruitYourself.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Infrastructure.Mapping;
    using RecruitYourself.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEventsService events;
        private readonly IArticlesService articles;

        public HomeController(IEventsService events, IArticlesService articles)
        {
            this.events = events;
            this.articles = articles;
        }

        public ActionResult Index()
        {
            var newestEvents = this.Cache.Get(
                "newestEvents",
                () => this.events
                    .GetNewestEvents(WebControllerConstants.HomePageNewestEventsCount)
                    .To<EventIndexViewModel>()
                    .ToList(),
                30 * 60);

            var newestArticles = this.Cache.Get(
                "newestArticles",
                () => this.articles
                    .GetNewestEvents(WebControllerConstants.HomePageNewestArticlesCount)
                    .To<ArticleIndexViewModel>()
                    .ToList(),
                30 * 60);

            var viewModel = new IndexViewModel
            {
                Events = newestEvents,
                Articles = newestArticles
            };

            return this.View(viewModel);
        }
    }
}
