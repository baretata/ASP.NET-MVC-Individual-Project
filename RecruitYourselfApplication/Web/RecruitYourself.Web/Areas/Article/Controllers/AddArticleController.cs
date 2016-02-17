namespace RecruitYourself.Web.Areas.Article.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels;
    using Web.Controllers;

    [Authorize]
    public class AddArticleController : BaseController
    {
        private readonly IArticlesService articles;

        public AddArticleController(IArticlesService articles)
        {
            this.articles = articles;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(ArticleInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var article = this.Mapper.Map<Article>(model);
                article.CreatorId = userId;

                this.articles.Add(article);
                return this.RedirectToAction("Index", "AllArticles");
            }

            return this.View(model);
        }
    }
}