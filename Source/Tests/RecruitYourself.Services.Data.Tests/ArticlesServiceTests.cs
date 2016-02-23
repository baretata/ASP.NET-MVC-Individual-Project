namespace RecruitYourself.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    
    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;

    [TestFixture]
    public class ArticlesServiceTests
    {
        private IQueryable<Article> mockedArticles;
        private Mock<IArticlesService> mockedArticlesData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedArticles = new List<Article>().AsQueryable();
            mockedArticlesData = new Mock<IArticlesService>();
            
            mockedArticlesData
                .Setup(s => s.GetAll())
                .Returns(mockedArticles);

            mockedArticlesData
                .Setup(s => s.GetById("1"))
                .Returns(new Article { Id = 1 });

            mockedArticlesData
                .Setup(s => (s.GetByPage(1, 0, 10)))
                .Returns(mockedArticles);

            mockedArticlesData
                .Setup(s => s.Add(It.IsAny<Article>()))
                .Verifiable();
        }

        [Test]
        public void GetAllArticlesShouldNotReturnNull()
        {
            IQueryable<Article> articles = mockedArticlesData.Object.GetAll();
            Assert.AreNotEqual(null, articles);
        }

        [Test]
        public void GetByIdArticleIdShouldNotReturnNull()
        {
            Article article = mockedArticlesData.Object.GetById("1");
            Assert.AreEqual(1, article.Id);
        }

        [Test]
        public void AddArticleShouldBeCalled()
        {
            mockedArticlesData.Object.Add(new Article());
            mockedArticlesData.Verify(s => s.Add(It.IsAny<Article>()));
        }

        [Test]
        public void GetByPageArticlesDefaultValueShouldReturnZeroIfNoArticlesExist()
        {
            var count = mockedArticlesData.Object.GetByPage(1,0,10).Count();
            Assert.AreEqual(count, 0);
        }
    }
}
