namespace RecruitYourself.Services.Data
{
    using System;
    using System.Linq;

    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Web;

    public class EventsService : IEventsService
    {
        private readonly IDbRepository<Event> events;
        private readonly IIdentifierProvider identifierProvider;

        public EventsService(IDbRepository<Event> events, IIdentifierProvider identifierProvider)
        {
            this.events = events;
            this.identifierProvider = identifierProvider;
        }

        public Event GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var currentEvent = this.events.GetById(intId);
            return currentEvent;
        }

        public IQueryable<Event> GetRandomJokes(int count)
        {
            return this.events.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
