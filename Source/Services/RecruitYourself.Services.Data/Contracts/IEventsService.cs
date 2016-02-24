namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        Event GetById(string id);

        IQueryable<Event> SearchBy(string searchQuery);

        void Add(Event model);

        IQueryable<Event> GetByPage(int page, int skip, int take);

        IQueryable<Event> GetNewestEvents(int count);
    }
}
