namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IVolunteersService
    {
        IQueryable<Volunteer> GetAll();

        Volunteer GetById(string id);

        void Add(Volunteer model);

        void Save();

        void Delete(Volunteer model);

        void Delete(string id);
    }
}
