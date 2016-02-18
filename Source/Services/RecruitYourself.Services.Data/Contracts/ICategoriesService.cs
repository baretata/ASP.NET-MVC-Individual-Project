namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category GetById(int id);

        void Add(Category model);

        void Delete(Category model);

        void Delete(int id);

        void Save();
    }
}
