namespace RecruitYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using RecruitYourself.Common.Constants;

    public class Category : BaseModel<int>
    {
        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }
    }
}
