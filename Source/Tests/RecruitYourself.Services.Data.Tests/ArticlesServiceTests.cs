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
        private Mock<IArticlesService> articlesServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var ariclesMock = new List<Article>().AsQueryable();
            articlesServiceMock = new Mock<IArticlesService>();
            
            articlesServiceMock
                .Setup(s => s.GetAll())
                .Returns(ariclesMock);

            articlesServiceMock
                .Setup(s => s.GetById("1"))
                .Returns(new Article { Id = 1 });

            articlesServiceMock
                .Setup(s => (s.GetByPage(1, 0, 10)))
                .Returns(ariclesMock);

            articlesServiceMock
                .Setup(s => s.Add(It.IsAny<Article>()))
                .Verifiable();
        }

        [Test]
        public void GetAllArticlesShouldNotReturnNull()
        {
            IQueryable<Article> articles = articlesServiceMock.Object.GetAll();
            Assert.AreNotEqual(null, articles);
        }

        [Test]
        public void GetByIdArticleIdShouldNotReturnNull()
        {
            Article article = articlesServiceMock.Object.GetById("1");
            Assert.AreEqual(1, article.Id);
        }

        [Test]
        public void AddArticleShouldBeCalled()
        {
            articlesServiceMock.Object.Add(new Article());
            articlesServiceMock.Verify(s => s.Add(It.IsAny<Article>()));
        }

        [Test]
        public void GetByPageArticlesDefaultValueShouldReturnZeroIfNoArticlesExist()
        {
            var count = articlesServiceMock.Object.GetByPage(1,0,10).Count();
            Assert.AreEqual(count, 0);
        }
    }
}
