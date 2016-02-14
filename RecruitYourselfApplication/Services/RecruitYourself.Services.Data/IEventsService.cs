namespace RecruitYourself.Services.Data
{
    using System.Linq;

    using RecruitYourself.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetRandomJokes(int count);

        Event GetById(string id);
    }
}
