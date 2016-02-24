namespace RecruitYourself.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class IndexViewModel : IMapFrom<Event>
    {
        public IList<EventIndexViewModel> Events { get; set; }

        public IEnumerable<ArticleIndexViewModel> Articles { get; set; }
    }
}
