﻿namespace RecruitYourself.Web.Controllers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Web.Areas.Event.Controllers;
    using RecruitYourself.Web.Areas.Event.ViewModels;
    using RecruitYourself.Web.Infrastructure.Mapping;

    using TestStack.FluentMVCTesting;

    [TestFixture]
    public class AllEventsControllerTests
    {
        private const string EventName = "Event name";
        private const string EventDescription = "Event's content";

        private Mock<IEventsService> eventsServiceMock;

        [OneTimeSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(AllEventsController).Assembly);

            var eventData = new Event { Name = EventName, Description = EventDescription, StartTime = DateTime.UtcNow, EndTime = DateTime.UtcNow.AddDays(2), CategoryId = 1 };
            var eventsMock = new List<Event>() { eventData }.AsQueryable();
            this.eventsServiceMock = new Mock<IEventsService>();

            this.eventsServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
               .Returns(eventData);

            this.eventsServiceMock.Setup(x => x.GetAll())
                .Returns(eventsMock);
        }

        [Test]
        public void EventByIdShouldReturnTheCorrectViewWithCorrectViewModel()
        {
            var controller = new AllEventsController(this.eventsServiceMock.Object);
            controller.WithCallTo(x => x.ById("id"))
               .ShouldRenderView("ById")
               .WithModel<EventViewModel>(
                   viewModel =>
                   {
                       Assert.AreEqual(EventName, viewModel.Name);
                   })
                .AndNoModelErrors();
        }

        //[Test]
        //public void EventIndexPageShouldReturnTheCorrectViewWithCorrectViewModel()
        //{
        //    var controller = new AllEventsController(this.eventsServiceMock.Object);
        //    controller.WithCallTo(x => x.Index(null, 1))
        //       .ShouldRenderView("Index")
        //       .WithModel<EventListViewModel>(
        //           viewModel =>
        //           {
        //               Assert.AreNotEqual(null, viewModel.Events);
        //           })
        //        .AndNoModelErrors();
        //}
    }
}
