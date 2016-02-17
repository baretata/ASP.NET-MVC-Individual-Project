namespace RecruitYourself.Web.ViewModels.Users
{
    using System.Collections.Generic;
    using Areas.Article.ViewModels;
    using RecruitYourself.Web.ViewModels.Home;

    public class OrganizationViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public IEnumerable<VolunteerViewModel> Members { get; set; }

        public IEnumerable<EventViewModel> Events { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
