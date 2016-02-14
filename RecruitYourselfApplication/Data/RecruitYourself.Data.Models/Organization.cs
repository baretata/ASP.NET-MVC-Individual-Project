namespace RecruitYourself.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;

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
        [MinLength(3)]
        [MaxLength(40)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(300)]
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

        // public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Organization> manager)
        // {
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

        // // Add custom user claims here
        //    return userIdentity;
        // }
    }
}
