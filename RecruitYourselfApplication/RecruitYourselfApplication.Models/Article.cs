namespace RecruitYourselfApplication.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        public Article()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("CreatorId")]
        public virtual Organization Creator { get; set; }

        [Required]
        public string CreatorId { get; set; }
    }
}
