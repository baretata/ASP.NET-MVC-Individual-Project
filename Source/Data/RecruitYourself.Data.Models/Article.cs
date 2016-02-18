namespace RecruitYourself.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;
    using RecruitYourself.Common.Constants;

    public class Article : BaseModel<int>
    {
        public Article()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DatabaseModelsConstants.ContentMaxLength)]
        public string Content { get; set; }

        [ForeignKey("CreatorId")]
        public virtual Organization Creator { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
}
