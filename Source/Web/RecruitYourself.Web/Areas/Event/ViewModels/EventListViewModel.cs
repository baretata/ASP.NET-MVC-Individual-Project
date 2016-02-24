namespace RecruitYourself.Web.Areas.Event.ViewModels
{
    using System.Collections.Generic;

    public class EventListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }
    }
}
