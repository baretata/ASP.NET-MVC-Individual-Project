namespace RecruitYourself.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;

    public class VolunteersService : IVolunteersService
    {
        private readonly IDbRepository<Volunteer, string> volunteers;

        public VolunteersService(IDbRepository<Volunteer, string> volunteers)
        {
            this.volunteers = volunteers;
        }

        public void Add(Volunteer model)
        {
            this.volunteers.Add(model);
            this.volunteers.Save();
        }

        public IQueryable<Volunteer> GetAll()
        {
            return this.volunteers.All().OrderBy(x => x.UserName);
        }

        public Volunteer GetById(string id)
        {
            return this.volunteers.GetById(id);
        }

        public void Delete(Volunteer model)
        {
            this.volunteers.Delete(model);
            this.volunteers.Save();
        }

        public void Delete(string id)
        {
            this.volunteers.Delete(id);
            this.volunteers.Save();
        }

        public void Save()
        {
            this.volunteers.Save();
        }
    }
}
