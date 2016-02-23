namespace RecruitYourself.Web.Areas.Event.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Event.ViewModels;
    using RecruitYourself.Web.Controllers;
    using RecruitYourself.Web.Infrastructure.Mapping;

    [Authorize]
    public class AddEventController : BaseController
    {
        private IEventsService events;
        private ICategoriesService categories;

        public AddEventController(IEventsService events, ICategoriesService categories)
        {
            this.events = events;
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateViewModel
            {
                Categories = this.GetCategories()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var currentEvent = this.Mapper.Map<Event>(model.InputModel);
                currentEvent.CreatorId = userId;

                this.events.Add(currentEvent);

                return this.RedirectToAction("Index", "AllEvents");
            }

            model.Categories = this.GetCategories();
            //model.InputModel.StartTime = null;
            //model.InputModel.EndTime = null;

            return this.View(model);
        }

        [NonAction]
        public IEnumerable<SelectListItem> GetCategories()
        {
            var allCategories = this.categories.GetAll().To<CategoryViewModel>().ToList();
            var categoryDropdownData = new List<SelectListItem>();

            foreach (var category in allCategories)
            {
                SelectListItem categoryItem = new SelectListItem
                {
                    Text = category.Name,
                    Value = category.Id.ToString()
                };

                categoryDropdownData.Add(categoryItem);
            }

            return categoryDropdownData;
        }
    }
}
