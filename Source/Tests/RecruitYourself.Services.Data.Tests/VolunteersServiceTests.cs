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
        private Mock<IVolunteersService> volunteerServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var volunteersMock = new List<Volunteer>().AsQueryable();
            volunteerServiceMock = new Mock<IVolunteersService>();

            volunteerServiceMock
                .Setup(s => s.GetAll())
                .Returns(volunteersMock);

            volunteerServiceMock
                .Setup(s => s.GetById("1"))
                .Returns(new Volunteer { Id = "1" });

            volunteerServiceMock
                .Setup(s => s.Delete(It.IsAny<Volunteer>()))
                .Verifiable();

            volunteerServiceMock
                .Setup(s => s.Add(It.IsAny<Volunteer>()))
                .Verifiable();
        }

        [Test]
        public void GetAllVolunteersShouldNotReturnNull()
        {
            IQueryable<Volunteer> volunteers = volunteerServiceMock.Object.GetAll();
            Assert.AreNotEqual(null, volunteers);
        }

        [Test]
        public void GetByIdVolunteerShouldNotReturnNull()
        {
            Volunteer volunteer = volunteerServiceMock.Object.GetById("1");
            Assert.AreEqual("1", volunteer.Id);
        }

        [Test]
        public void AddVoluneteerShouldBeCalled()
        {
            volunteerServiceMock.Object.Add(new Volunteer());
            volunteerServiceMock.Verify(s => s.Add(It.IsAny<Volunteer>()));
        }

        [Test]
        public void DeleteVolunteerShouldBeCalled()
        {
            volunteerServiceMock.Object.Delete(new Volunteer());
            volunteerServiceMock.Verify(s => s.Delete(It.IsAny<Volunteer>()));
        }
    }
}
