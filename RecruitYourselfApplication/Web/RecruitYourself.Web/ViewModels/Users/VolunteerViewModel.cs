namespace RecruitYourself.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using RecruitYourself.Web.ViewModels.Home;

    public class VolunteerViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public short Age { get; set; }

        public IEnumerable<EventViewModel> Favorites { get; set; }

        public IEnumerable<EventViewModel> Volunteerships { get; set; }
    }
}