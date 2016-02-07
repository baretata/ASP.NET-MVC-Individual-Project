namespace RecruitYourselfApplication.Data.Contracts
{
    using Models;

    public interface IRecruitYourselfData
    {
        IGenericRepository<Volunteer> Volunteers { get; }

        IGenericRepository<Event> Events { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Organization> Organizations { get; }

        IGenericRepository<Article> Articles { get; }

        void SaveChanges();
    }
}
