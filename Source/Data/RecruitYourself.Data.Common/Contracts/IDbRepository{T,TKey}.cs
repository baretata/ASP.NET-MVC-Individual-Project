namespace RecruitYourself.Data.Common.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Common.Models;

    /* public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
     {
     } */

    public interface IDbRepository<T, in TKey>
        where T : class, IBaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void Delete(TKey id);

        void HardDelete(T entity);

        void Save();
    }
}
