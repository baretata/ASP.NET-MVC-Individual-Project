namespace RecruitYourself.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Article.Controllers;
    using RecruitYourself.Web.Areas.Article.ViewModels;
    using RecruitYourself.Web.Infrastructure.Mapping;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class AllArticlesControllerTests
    {
        private const string ArticleName = "Article name";
        private const string ArticleContent = "Article's content";

        private Mock<IArticlesService> articlesServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(AllArticlesController).Assembly);

            this.articlesServiceMock = new Mock<IArticlesService>();

            this.articlesServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
               .Returns(new Article { Name = ArticleName, Content = ArticleContent });
        }

        [Test]
        public void ArticleByIdShouldReturnTheCorrectViewWithCorrectViewModel()
        {
            var controller = new AllArticlesController(this.articlesServiceMock.Object);
            controller.WithCallTo(x => x.ById("id"))
               .ShouldRenderView("ById")
               .WithModel<ArticleViewModel>(
                   viewModel =>
                    {
                        Assert.AreEqual(ArticleContent, viewModel.Content);
                    })
                .AndNoModelErrors();
        }
    }
}
