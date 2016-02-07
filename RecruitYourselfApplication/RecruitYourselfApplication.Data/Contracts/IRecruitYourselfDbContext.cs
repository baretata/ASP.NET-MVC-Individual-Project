namespace RecruitYourselfApplication.Data.Contracts
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IRecruitYourselfDbContext
    {
        IDbSet<Event> Events { get; set; }

        IDbSet<Category> Categories { get; set; }
        
        IDbSet<Organization> Organizations { get; set; }

        IDbSet<Volunteer> Volunteers { get; set; }

        IDbSet<Article> Articles { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry Entry<T>(T entity) where T : class;

        int SaveChanges();

        void Dispose();
    }
}
