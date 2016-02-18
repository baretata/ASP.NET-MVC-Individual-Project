namespace RecruitYourself.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;

    public class Organization : User
    {
        private ICollection<Volunteer> members;
        private ICollection<Event> events;
        private ICollection<Article> articles;

        public Organization()
        {
            this.members = new HashSet<Volunteer>();
            this.events = new HashSet<Event>();
            this.articles = new HashSet<Article>();
        }

        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string Address { get; set; }

        public virtual ICollection<Volunteer> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return this.events; }
            set { this.events = value; }
        }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }
            set { this.articles = value; }
        }
    }
}
