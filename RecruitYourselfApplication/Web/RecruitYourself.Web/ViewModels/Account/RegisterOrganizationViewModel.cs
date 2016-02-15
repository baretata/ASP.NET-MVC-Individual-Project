namespace RecruitYourself.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterOrganizationViewModel : RegisterBaseViewModel
    {
        [Required]
        [StringLength(
            40,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 3)]
        [Display(Name = "Ogranization Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(
            300,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 10)]
        public string Address { get; set; }
    }
}
