namespace RecruitYourselfApplication.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterBaseViewModel
    {
        [Required]
        [StringLength(40,
            ErrorMessage = "The {0} must be between {2} and {1} characters long.",
            MinimumLength = 3)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, 
            ErrorMessage = "The {0} must be between {2} and {1} characters long.", 
            MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(300, 
            ErrorMessage = "The {0} must be between {2} and {1} characters long.", 
            MinimumLength = 10)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [DataType(DataType.Upload)]
        public string Image { get; set; }
    }
}