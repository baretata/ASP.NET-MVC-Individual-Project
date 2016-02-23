namespace RecruitYourself.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;

    [TestFixture]
    public class OrganizationsServiceTests
    {
        private IQueryable<Organization> mockedOrganizations;
        private Mock<IOrganizationsService> mockedOrganizationsData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedOrganizations = new List<Organization>().AsQueryable();
            mockedOrganizationsData = new Mock<IOrganizationsService>();

            mockedOrganizationsData
                .Setup(s => s.GetAll())
                .Returns(mockedOrganizations);

            mockedOrganizationsData
                .Setup(s => s.GetById("1"))
                .Returns(new Organization { Id = "1" });

            mockedOrganizationsData
                .Setup(s => s.Delete(It.IsAny<Organization>()))
                .Verifiable();

            mockedOrganizationsData
                .Setup(s => s.Add(It.IsAny<Organization>()))
                .Verifiable();
        }

        [Test]
        public void GetAllOrganizationsShouldNotReturnNull()
        {
            IQueryable<Organization> organizations = mockedOrganizationsData.Object.GetAll();
            Assert.AreNotEqual(null, organizations);
        }

        [Test]
        public void GetByIdOrganizationShouldNotReturnNull()
        {
            Organization organization = mockedOrganizationsData.Object.GetById("1");
            Assert.AreEqual("1", organization.Id);
        }

        [Test]
        public void AddOrganizationShouldBeCalled()
        {
            mockedOrganizationsData.Object.Add(new Organization());
            mockedOrganizationsData.Verify(s => s.Add(It.IsAny<Organization>()));
        }

        [Test]
        public void DeleteOrganizationShouldBeCalled()
        {
            mockedOrganizationsData.Object.Delete(new Organization());
            mockedOrganizationsData.Verify(s => s.Delete(It.IsAny<Organization>()));
        }
    }
}
