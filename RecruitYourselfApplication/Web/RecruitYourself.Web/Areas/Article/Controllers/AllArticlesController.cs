namespace RecruitYourself.Web.Areas.Article.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Common.Constants;
    using Infrastructure.Mapping;
    using RecruitYourself.Web.Controllers;
    using Services.Data.Contracts;
    using ViewModels;

    public class AllArticlesController : BaseController
    {
        private readonly IArticlesService articles;

        public AllArticlesController(IArticlesService articles)
        {
            this.articles = articles;
        }

        [HttpGet]
        public ActionResult Index(string searchQuery, int id = 1)
        {
            IList<ArticleViewModel> articleModels;
            int page;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                page = 1;

                articleModels = this.articles
                    .SearchBy(searchQuery)
                    .To<ArticleViewModel>()
                    .ToList();
            }
            else
            {
                page = id;

                articleModels = this.articles
                   .GetAll()
                   .To<ArticleViewModel>()
                   .ToList();
            }

            int allArticlesCount = articleModels.Count;
            int totalPages = (int)Math.Ceiling(allArticlesCount / (decimal)WebControllerConstants.ArticlesPerPage);
            int skippedArticles = (page - 1) * WebControllerConstants.ArticlesPerPage;
            var takenArticles = articleModels
                .Skip(skippedArticles)
                .Take(WebControllerConstants.ArticlesPerPage);

            var viewModel = new ArticleListViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Articles = takenArticles
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult ById(string id)
        {
            var article = this.articles.GetById(id);
            var viewModel = this.Mapper.Map<ArticleViewModel>(article);

            return this.View(viewModel);
        }
    }
}