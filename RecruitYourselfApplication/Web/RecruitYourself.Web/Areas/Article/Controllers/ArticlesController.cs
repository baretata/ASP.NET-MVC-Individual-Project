namespace RecruitYourself.Web.Areas.Article.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using RecruitYourself.Web.Controllers;
    using Services.Data.Contracts;
    using ViewModels;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articles;

        public ArticlesController(IArticlesService articles)
        {
            this.articles = articles;
        }

        public ActionResult Index(string searchQuery)
        {
            IList<ArticleViewModel> articleModels;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                articleModels = this.articles
                    .SearchBy(searchQuery)
                    .To<ArticleViewModel>()
                    .ToList();
            }
            else
            {
                articleModels = this.articles
                   .GetAll()
                   .To<ArticleViewModel>()
                   .ToList();
            }

            return this.View(articleModels);
        }

        public ActionResult ById(string id)
        {
            var article = this.articles.GetById(id);
            var viewModel = this.Mapper.Map<ArticleViewModel>(article);

            return this.View(viewModel);
        }
    }
}