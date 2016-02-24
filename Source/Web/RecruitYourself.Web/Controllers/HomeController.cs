namespace RecruitYourself.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Infrastructure.Mapping;
    using RecruitYourself.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEventsService events;

        public HomeController(IEventsService events)
        {
            this.events = events;
        }

        public ActionResult Index()
        {
            var events = this.events.GetNewestEvents(3).To<HomeEventViewModel>().ToList();

            // var categories =
            //    this.Cache.Get(
            //        "categories",
            //        () => this.categories.GetAll().To<CategoryViewModel>().ToList(),
            //        30 * 60);

            return this.View(events);
        }
    }
}
