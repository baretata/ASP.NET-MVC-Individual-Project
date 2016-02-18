namespace RecruitYourself.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class VolunteerInputModel : IMapTo<Volunteer>
    {
        public string Id { get; set; }

        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
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