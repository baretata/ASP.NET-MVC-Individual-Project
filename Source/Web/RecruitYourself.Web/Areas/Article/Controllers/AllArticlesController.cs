﻿namespace RecruitYourself.Web.Areas.Article.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using RecruitYourself.Common.Constants;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Article.ViewModels;
    using RecruitYourself.Web.Controllers;
    using RecruitYourself.Web.Infrastructure.Mapping;

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
            int totalPages = (int)Math.Ceiling(allArticlesCount / (decimal)WebControllerConstants.ItemsPerPage);
            int skippedArticles = (page - 1) * WebControllerConstants.ItemsPerPage;
            var takenArticles = articleModels
                .Skip(skippedArticles)
                .Take(WebControllerConstants.ItemsPerPage);

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
