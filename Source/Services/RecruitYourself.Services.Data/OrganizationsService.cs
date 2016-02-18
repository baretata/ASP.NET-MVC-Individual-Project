namespace RecruitYourself.Services.Data
{
    using System;
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
            throw new NotImplementedException();
        }

        public IQueryable<Organization> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
