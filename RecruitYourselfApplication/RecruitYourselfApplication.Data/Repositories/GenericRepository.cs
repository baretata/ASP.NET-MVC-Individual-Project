namespace RecruitYourselfApplication.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common.Constants;
    using Contracts;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository(IRecruitYourselfDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException(DatabaseMessages.DbContextNotFoundMessage, nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected IDbSet<TEntity> DbSet { get; set; }

        protected IRecruitYourselfDbContext Context { get; set; }

        public void Add(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public IQueryable<TEntity> All()
        {
            return this.DbSet.AsQueryable();
        }

        public TEntity Attach(TEntity entity)
        {
            return this.Context.Set<TEntity>().Attach(entity);
        }

        public void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public void Detach(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public TEntity GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
