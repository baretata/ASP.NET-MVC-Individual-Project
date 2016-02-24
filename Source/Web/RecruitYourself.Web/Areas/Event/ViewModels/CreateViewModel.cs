namespace RecruitYourself.Web.Areas.Event.ViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CreateViewModel
    {
        public EventInputModel InputModel { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
