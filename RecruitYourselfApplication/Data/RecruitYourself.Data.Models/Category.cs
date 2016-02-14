namespace RecruitYourself.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Category : BaseModel<int>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}
