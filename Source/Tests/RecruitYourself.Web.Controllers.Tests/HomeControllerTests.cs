namespace RecruitYourself.Web.Controllers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Event.Controllers;
    using RecruitYourself.Web.Infrastructure.Mapping;
    using RecruitYourself.Web.ViewModels.Home;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class HomeControllerTests
    {
        private const string EventName = "Event name";
        private const string EventDescription = "Event's content";

        private Mock<IEventsService> eventsServiceMock;
        private Mock<IArticlesService> articlesServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(AllEventsController).Assembly);

            var eventData = new Event { Name = EventName, Description = EventDescription, StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddDays(2), CategoryId = 1 };
            var eventsMock = new List<Event>() { eventData }.AsQueryable();
            this.eventsServiceMock = new Mock<IEventsService>();
            this.articlesServiceMock = new Mock<IArticlesService>();

            this.eventsServiceMock.Setup(x => x.GetAll())
                .Returns(eventsMock);
        }

        [Test]
        public void EventCreateShouldReturnTheCorrectViewWithCorrectViewModel()
        {
            var controller = new HomeController(this.eventsServiceMock.Object, this.articlesServiceMock.Object);
            controller.WithCallTo(x => x.Index())
               .ShouldRenderView("Index")
               .WithModel<IndexViewModel>(
                   viewModel =>
                   {
                       Assert.AreNotEqual(null, viewModel.Articles);
                       Assert.AreNotEqual(null, viewModel.Events);
                   })
                .AndNoModelErrors();
        }
    }
}
