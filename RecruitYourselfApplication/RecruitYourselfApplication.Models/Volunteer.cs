namespace RecruitYourselfApplication.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    public class Volunteer : User
    {
        private ICollection<Event> favorites;
        private ICollection<Event> volunteerships;

        public Volunteer()
        {
            this.favorites = new HashSet<Event>();
            this.volunteerships = new HashSet<Event>();
        }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        public string LastName { get; set; }
        
        public short Age { get; set; }
        

        public virtual ICollection<Event> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }

        public virtual ICollection<Event> Volunteerships
        {
            get { return this.volunteerships; }
            set { this.volunteerships = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Volunteer> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
