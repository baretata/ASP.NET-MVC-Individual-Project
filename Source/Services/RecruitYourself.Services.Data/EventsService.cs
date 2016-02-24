namespace RecruitYourself.Services.Data
{
    using System;
    using System.Linq;

    using RecruitYourself.Data.Common.Contracts;
    using RecruitYourself.Data.Models;
    using RecruitYourself.Services.Data.Contracts;
    using RecruitYourself.Services.Web.Contracts;

    public class EventsService : IEventsService
    {
        private readonly IDbRepository<Event, int> events;
        private readonly IIdentifierProvider identifierProvider;

        public EventsService(IDbRepository<Event, int> events, IIdentifierProvider identifierProvider)
        {
            this.events = events;
            this.identifierProvider = identifierProvider;
        }

        public void Add(Event model)
        {
            this.events.Add(model);
            this.events.Save();
        }

        public IQueryable<Event> GetAll()
        {
            return this.events.All().OrderByDescending(x => x.CreatedOn);
        }

        public Event GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var currentEvent = this.events.GetById(intId);

            return currentEvent;
        }

        public IQueryable<Event> GetByPage(int page, int skip, int take)
        {
            return this.events.All().Skip(skip).Take(take);
        }

        public IQueryable<Event> GetNewestEvents(int count)
        {
            return this.events.All()
                .Where(x => x.StartTime > DateTime.UtcNow)
                .OrderBy(x => x.StartTime);
        }

        public IQueryable<Event> SearchBy(string searchQuery)
        {
            return this.events
                .All()
                .Where(a => a.Name.Contains(searchQuery) || a.Description.Contains(searchQuery))
                .OrderBy(x => x.CreatedOn);
        }
    }
}
