namespace RecruitYourself.Services.Data
{
    using System;
    using System.Linq;

    using Contracts;
    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDbRepository<Category, int> categories;

        public CategoriesService(IDbRepository<Category, int> categories)
        {
            this.categories = categories;
        }

        public void Add(Category model)
        {
            this.categories.Add(model);
            this.categories.Save();
        }

        public void Delete(int id)
        {
            this.categories.Delete(id);
            this.categories.Save();
        }

        public void Delete(Category model)
        {
            this.categories.Delete(model);
            this.categories.Save();
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }

        public void Save()
        {
            this.categories.Save();
        }
    }
}
