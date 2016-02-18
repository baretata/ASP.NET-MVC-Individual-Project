namespace RecruitYourself.Web.Areas.Administration.ViewModels.Volunteer
{
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class VolunteerInputModel : IMapTo<Volunteer>
    {
        public string Id { get; set; }

        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MinLength(DatabaseModelsConstants.UserDescriptionMinLength)]
        [MaxLength(DatabaseModelsConstants.UserDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(DatabaseModelsConstants.AgeMinRange, DatabaseModelsConstants.AgeMaxRange)]
        public short Age { get; set; }
    }
}
