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
        private IQueryable<Category> mockedCategories;
        private Mock<ICategoriesService> mockedCategoriesData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedCategories = new List<Category>().AsQueryable();
            mockedCategoriesData = new Mock<ICategoriesService>();

            mockedCategoriesData
                .Setup(s => s.GetAll())
                .Returns(mockedCategories);

            mockedCategoriesData
                .Setup(s => s.GetById(1))
                .Returns(new Category { Id = 1 });

            mockedCategoriesData
                .Setup(s => s.Delete(It.IsAny<Category>()))
                .Verifiable();

            mockedCategoriesData
                .Setup(s => s.Add(It.IsAny<Category>()))
                .Verifiable();
        }

        [Test]
        public void GetAllCategoriesShouldNotReturnNull()
        {
            IQueryable<Category> categories = mockedCategoriesData.Object.GetAll();
            Assert.AreNotEqual(null, categories);
        }

        [Test]
        public void GetByIdCategoryShouldNotReturnNull()
        {
            Category category = mockedCategoriesData.Object.GetById(1);
            Assert.AreEqual(1, category.Id);
        }

        [Test]
        public void AddCategoryShouldBeCalled()
        {
            mockedCategoriesData.Object.Add(new Category());
            mockedCategoriesData.Verify(s => s.Add(It.IsAny<Category>()));
        }

        [Test]
        public void DeleteCategoryShouldBeCalled()
        {
            mockedCategoriesData.Object.Delete(new Category());
            mockedCategoriesData.Verify(s => s.Delete(It.IsAny<Category>()));
        }
    }
}
