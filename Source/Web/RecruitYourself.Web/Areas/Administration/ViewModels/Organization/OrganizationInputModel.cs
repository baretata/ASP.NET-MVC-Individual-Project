namespace RecruitYourself.Web.Areas.Administration.ViewModels.Organization
{
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;

    public class OrganizationInputModel
    {
        public string Id { get; set; }

        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }

        [MinLength(DatabaseModelsConstants.AddressMinLength)]
        [MaxLength(DatabaseModelsConstants.AddressMaxLength)]
        public string Address { get; set; }

        [MinLength(DatabaseModelsConstants.UserDescriptionMinLength)]
        [MaxLength(DatabaseModelsConstants.UserDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
