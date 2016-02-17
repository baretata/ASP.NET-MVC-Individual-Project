namespace RecruitYourself.Services.Data
{
    using System;
    using System.Linq;
    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using Web.Contracts;

    public class ArticlesService : IArticlesService
    {
        private readonly IDbRepository<Article> articles;
        private readonly IIdentifierProvider identifierProvider;

        public ArticlesService(IDbRepository<Article> articles, IIdentifierProvider identifierProvider)
        {
            this.articles = articles;
            this.identifierProvider = identifierProvider;
        }

        public void Add(Article model)
        {
            this.articles.Add(model);
            this.articles.Save();
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All().OrderBy(x => x.CreatedOn);
        }

        public Article GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var currentArticle = this.articles.GetById(intId);

            return currentArticle;
        }

        public IQueryable<Article> GetByPage(int page, int skip, int take)
        {
            return this.articles.All().Skip(skip).Take(take);
        }

        public IQueryable<Article> SearchBy(string searchQuery)
        {
            return this.articles
                .All()
                .Where(a => a.Name.Contains(searchQuery) || a.Content.Contains(searchQuery))
                .OrderBy(x => x.CreatedOn);
        }
    }
}
