namespace RecruitYourself.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;

    [TestFixture]
    public class EventsServiceTests
    {
        private Mock<IEventsService> eventsServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var eventsMock = new List<Event>().AsQueryable();
            eventsServiceMock = new Mock<IEventsService>();

            eventsServiceMock
                .Setup(s => s.GetAll())
                .Returns(eventsMock);

            eventsServiceMock
                .Setup(s => s.GetById("1"))
                .Returns(new Event { Id = 1 });

            eventsServiceMock
                .Setup(s => (s.GetByPage(1, 0, 10)))
                .Returns(eventsMock);

            eventsServiceMock
                .Setup(s => s.Add(It.IsAny<Event>()))
                .Verifiable();
        }

        [Test]
        public void GetAllEventsShouldNotReturnNull()
        {
            IQueryable<Event> articles = eventsServiceMock.Object.GetAll();
            Assert.AreNotEqual(null, articles);
        }

        [Test]
        public void GetByIdEventIdShouldNotReturnNull()
        {
            Event currentEvent = eventsServiceMock.Object.GetById("1");
            Assert.AreEqual(1, currentEvent.Id);
        }

        [Test]
        public void AddEventShouldBeCalled()
        {
            eventsServiceMock.Object.Add(new Event());
            eventsServiceMock.Verify(s => s.Add(It.IsAny<Event>()));
        }

        [Test]
        public void GetByPageEventsDefaultValueShouldReturnZeroIfNoEventsExist()
        {
            var count = eventsServiceMock.Object.GetByPage(1, 0, 10).Count();
            Assert.AreEqual(count, 0);
        }
    }
}
