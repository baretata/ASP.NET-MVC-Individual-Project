namespace RecruitYourself.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data.Contracts;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEventsService events;
        private readonly ICategoriesService categories;

        public HomeController(
            IEventsService events,
            ICategoriesService jokeCategories)
        {
            this.events = events;
            this.categories = jokeCategories;
        }

        public ActionResult Index()
        {
            var events = this.events.GetRandomEvents(3).To<EventViewModel>().ToList();

            // var categories =
            //    this.Cache.Get(
            //        "categories",
            //        () => this.categories.GetAll().To<CategoryViewModel>().ToList(),
            //        30 * 60);
            var viewModel = new IndexViewModel
            {
                Events = events,
                // Categories = categories
            };

            return this.View(viewModel);
        }
    }
}
