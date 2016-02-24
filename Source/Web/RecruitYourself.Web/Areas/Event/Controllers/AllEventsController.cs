namespace RecruitYourself.Web.Areas.Event.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Event.ViewModels;
    using RecruitYourself.Web.Controllers;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class AllEventsController : BaseController
    {
        private readonly IEventsService events;

        public AllEventsController(IEventsService events)
        {
            this.events = events;
        }

        [HttpGet]
        public ActionResult Index(string searchQuery, int id = 1)
        {
            IList<EventViewModel> eventModels;
            int page;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                page = 1;

                eventModels = this.events
                    .SearchBy(searchQuery)
                    .To<EventViewModel>()
                    .ToList();
            }
            else
            {
                page = id;

                eventModels = this.events
                   .GetAll()
                   .To<EventViewModel>()
                   .ToList();
            }

            int allEventsCount = eventModels.Count;
            int totalPages = (int)Math.Ceiling(allEventsCount / (decimal)WebControllerConstants.ItemsPerPage);
            int skippedEvents = (page - 1) * WebControllerConstants.ItemsPerPage;
            var takenEvents = eventModels
                .Skip(skippedEvents)
                .Take(WebControllerConstants.ItemsPerPage);

            var viewModel = new EventListViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Events = takenEvents
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult ById(string id)
        {
            var currentEvent = this.events.GetById(id);
            var viewModel = this.Mapper.Map<EventViewModel>(currentEvent);

            return this.View(viewModel);
        }
    }
}
