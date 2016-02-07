namespace RecruitYourselfApplication.Data.Contracts
{
    using System.Linq;

    public interface IGenericRepository<TEntity> 
        where TEntity : class
    {
        IQueryable<TEntity> All();

        TEntity GetById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        TEntity Attach(TEntity entity);

        void Detach(TEntity entity);
    }
}
