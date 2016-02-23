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
        private Mock<IOrganizationsService> organizationServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var organizationsMock = new List<Organization>().AsQueryable();
            organizationServiceMock = new Mock<IOrganizationsService>();

            organizationServiceMock
                .Setup(s => s.GetAll())
                .Returns(organizationsMock);

            organizationServiceMock
                .Setup(s => s.GetById("1"))
                .Returns(new Organization { Id = "1" });

            organizationServiceMock
                .Setup(s => s.Delete(It.IsAny<Organization>()))
                .Verifiable();

            organizationServiceMock
                .Setup(s => s.Add(It.IsAny<Organization>()))
                .Verifiable();
        }

        [Test]
        public void GetAllOrganizationsShouldNotReturnNull()
        {
            IQueryable<Organization> organizations = organizationServiceMock.Object.GetAll();
            Assert.AreNotEqual(null, organizations);
        }

        [Test]
        public void GetByIdOrganizationShouldNotReturnNull()
        {
            Organization organization = organizationServiceMock.Object.GetById("1");
            Assert.AreEqual("1", organization.Id);
        }

        [Test]
        public void AddOrganizationShouldBeCalled()
        {
            organizationServiceMock.Object.Add(new Organization());
            organizationServiceMock.Verify(s => s.Add(It.IsAny<Organization>()));
        }

        [Test]
        public void DeleteOrganizationShouldBeCalled()
        {
            organizationServiceMock.Object.Delete(new Organization());
            organizationServiceMock.Verify(s => s.Delete(It.IsAny<Organization>()));
        }
    }
}
