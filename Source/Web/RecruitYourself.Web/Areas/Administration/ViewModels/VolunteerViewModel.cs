namespace RecruitYourself.Web.ViewModels.Users
{
    using System;

    public class VolunteerViewModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public short Age { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
