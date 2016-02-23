namespace RecruitYourself.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;

    [TestFixture]
    public class CategoriesServiceTests
    {
        private Mock<ICategoriesService> categoriesServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var categoriesMock = new List<Category>().AsQueryable();
            categoriesServiceMock = new Mock<ICategoriesService>();

            categoriesServiceMock
                .Setup(s => s.GetAll())
                .Returns(categoriesMock);

            categoriesServiceMock
                .Setup(s => s.GetById(1))
                .Returns(new Category { Id = 1 });

            categoriesServiceMock
                .Setup(s => s.Delete(It.IsAny<Category>()))
                .Verifiable();

            categoriesServiceMock
                .Setup(s => s.Add(It.IsAny<Category>()))
                .Verifiable();
        }

        [Test]
        public void GetAllCategoriesShouldNotReturnNull()
        {
            IQueryable<Category> categories = categoriesServiceMock.Object.GetAll();
            Assert.AreNotEqual(null, categories);
        }

        [Test]
        public void GetByIdCategoryShouldNotReturnNull()
        {
            Category category = categoriesServiceMock.Object.GetById(1);
            Assert.AreEqual(1, category.Id);
        }

        [Test]
        public void AddCategoryShouldBeCalled()
        {
            categoriesServiceMock.Object.Add(new Category());
            categoriesServiceMock.Verify(s => s.Add(It.IsAny<Category>()));
        }

        [Test]
        public void DeleteCategoryShouldBeCalled()
        {
            categoriesServiceMock.Object.Delete(new Category());
            categoriesServiceMock.Verify(s => s.Delete(It.IsAny<Category>()));
        }
    }
}
