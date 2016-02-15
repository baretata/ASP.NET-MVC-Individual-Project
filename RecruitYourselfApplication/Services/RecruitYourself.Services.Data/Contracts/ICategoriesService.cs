namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<Category> GetAll();

        Category EnsureCategory(string name);
    }
}
