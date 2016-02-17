namespace RecruitYourself.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Common.Models;

    public class Article : BaseModel<int>
    {
        public Article()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [ForeignKey("CreatorId")]
        public virtual Organization Creator { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
}
