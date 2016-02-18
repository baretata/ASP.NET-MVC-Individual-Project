namespace RecruitYourself.Web.Areas.Administration.ViewModels.Organization
{
    using RecruitYourself.Data.Models;
    using RecruitYourself.Web.Infrastructure.Mapping;

    public class OrganizationViewModel : BaseUserModel, IMapFrom<Organization>
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
