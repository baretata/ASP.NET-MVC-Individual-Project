namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IOrganizationsService
    {
        IQueryable<Organization> GetAll();

        Organization GetById(string id);

        void Add(Organization model);

        void Update(Organization model);

        void Delete(Organization model);

        void Delete(string id);
    }
}
