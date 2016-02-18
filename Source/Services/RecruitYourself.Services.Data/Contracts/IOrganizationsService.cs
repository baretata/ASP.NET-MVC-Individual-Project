namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();

        void Add(Organization model);
    }
}
