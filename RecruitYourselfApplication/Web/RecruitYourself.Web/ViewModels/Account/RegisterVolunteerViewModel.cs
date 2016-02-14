namespace RecruitYourself.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterVolunteerViewModel : RegisterBaseViewModel
    {
        [Required]
        [StringLength(
            40,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(
            40,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(
            0,
            120,
            ErrorMessage = "The {0} must be between {2} and {1}")]
        public short Age { get; set; }
    }
}