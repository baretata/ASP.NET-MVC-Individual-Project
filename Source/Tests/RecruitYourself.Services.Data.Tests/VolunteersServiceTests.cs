namespace RecruitYourself.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;

    [TestFixture]
    public class VolunteersServiceTests
    {
        private IQueryable<Volunteer> mockedVolunteers;
        private Mock<IVolunteersService> mockedVolunteersData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedVolunteers = new List<Volunteer>().AsQueryable();
            mockedVolunteersData = new Mock<IVolunteersService>();

            mockedVolunteersData
                .Setup(s => s.GetAll())
                .Returns(mockedVolunteers);

            mockedVolunteersData
                .Setup(s => s.GetById("1"))
                .Returns(new Volunteer { Id = "1" });

            mockedVolunteersData
                .Setup(s => s.Delete(It.IsAny<Volunteer>()))
                .Verifiable();

            mockedVolunteersData
                .Setup(s => s.Add(It.IsAny<Volunteer>()))
                .Verifiable();
        }

        [Test]
        public void GetAllVolunteersShouldNotReturnNull()
        {
            IQueryable<Volunteer> volunteers = mockedVolunteersData.Object.GetAll();
            Assert.AreNotEqual(null, volunteers);
        }

        [Test]
        public void GetByIdVolunteerShouldNotReturnNull()
        {
            Volunteer volunteer = mockedVolunteersData.Object.GetById("1");
            Assert.AreEqual("1", volunteer.Id);
        }

        [Test]
        public void AddVoluneteerShouldBeCalled()
        {
            mockedVolunteersData.Object.Add(new Volunteer());
            mockedVolunteersData.Verify(s => s.Add(It.IsAny<Volunteer>()));
        }

        [Test]
        public void DeleteVolunteerShouldBeCalled()
        {
            mockedVolunteersData.Object.Delete(new Volunteer());
            mockedVolunteersData.Verify(s => s.Delete(It.IsAny<Volunteer>()));
        }
    }
}
