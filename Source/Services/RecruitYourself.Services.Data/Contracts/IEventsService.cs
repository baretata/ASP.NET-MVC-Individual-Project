namespace RecruitYourself.Services.Data.Contracts
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetRandomEvents(int count);

        Event GetById(string id);
    }
}
