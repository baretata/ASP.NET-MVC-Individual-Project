namespace RecruitYourself.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEventsService events;
        private readonly ICategoriesService categories;

        public HomeController(
            IEventsService jokes,
            ICategoriesService jokeCategories)
        {
            this.events = jokes;
            this.categories = jokeCategories;
        }

        public ActionResult Index()
        {
            var jokes = this.events.GetRandomJokes(3).To<EventViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.categories.GetAll().To<CategoryViewModel>().ToList(),
                    30 * 60);
            var viewModel = new IndexViewModel
            {
                Events = jokes,
                Categories = categories
            };

            return this.View(viewModel);
        }
    }
}
