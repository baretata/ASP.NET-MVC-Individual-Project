namespace RecruitYourself.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RecruitYourself.Common.Constants;

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
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DatabaseModelsConstants.NameMinLength)]
        [MaxLength(DatabaseModelsConstants.NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [Range(DatabaseModelsConstants.AgeMinRange, DatabaseModelsConstants.AgeMaxRange)]
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
    }
}
