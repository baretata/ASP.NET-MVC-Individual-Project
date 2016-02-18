namespace RecruitYourself.Web.Areas.Administration.ViewModels.Volunteer
{
    using Data.Models;
    using Web.Infrastructure.Mapping;

    public class VolunteerViewModel : BaseUserModel, IMapFrom<Volunteer>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public short Age { get; set; }
    }
}
