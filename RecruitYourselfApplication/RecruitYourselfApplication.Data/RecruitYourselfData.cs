namespace RecruitYourselfApplication.Data
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Repositories;
    public class RecruitYourselfData : IRecruitYourselfData
    {
        private readonly IRecruitYourselfDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public RecruitYourselfData(IRecruitYourselfDbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<Article> Articles => this.GetRepository<Article>();

        public IGenericRepository<Category> Categories => this.GetRepository<Category>();

        public IGenericRepository<Event> Events => this.GetRepository<Event>();

        public IGenericRepository<Organization> Organizations => this.GetRepository<Organization>();

        public IGenericRepository<Volunteer> Volunteers => this.GetRepository<Volunteer>();

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        protected IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
