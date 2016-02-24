namespace RecruitYourself.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<HomeEventViewModel> Events { get; set; }
    }
}
