namespace RecruitYourself.Web.Areas.Administration.ViewModels
{
    using System;

    public class BaseAdministrationModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
