namespace RecruitYourself.Web.Areas.Administration.ViewModels.Organization
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class OrganizationViewModel : IMapFrom<Organization>
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
