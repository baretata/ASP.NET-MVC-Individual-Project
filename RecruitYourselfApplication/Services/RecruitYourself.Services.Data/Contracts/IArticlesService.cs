namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;
    using RecruitYourself.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        Article GetById(string id);

        IQueryable<Article> SearchBy(string searchQuery);

        void Add(Article model);

        IQueryable<Article> GetByPage(int page, int skip, int take);
    }
}
