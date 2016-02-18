namespace RecruitYourself.Services.Data
{
    using System.Linq;

    using Contracts;
    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;

    public class OrganizationsService : IOrganizationsService
    {
        private readonly IDbRepository<Organization, string> organizatons;

        public OrganizationsService(IDbRepository<Organization, string> organizatons)
        {
            this.organizatons = organizatons;
        }

        public void Add(Organization model)
        {
            this.organizatons.Add(model);
            this.organizatons.Save();
        }

        public IQueryable<Organization> GetAll()
        {
            return this.organizatons.All().OrderBy(x => x.UserName);
        }

        public Organization GetById(string id)
        {
            return this.organizatons.GetById(id);
        }

        public void Delete(Organization model)
        {
            this.organizatons.Delete(model);
            this.organizatons.Save();
        }

        public void Delete(string id)
        {
            this.organizatons.Delete(id);
            this.organizatons.Save();
        }

        public void Save()
        {
            this.organizatons.Save();
        }
    }
}
