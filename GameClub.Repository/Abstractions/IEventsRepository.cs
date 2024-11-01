using GameClub.Infrastructure.Models;

namespace GameClub.Repository.Abstractions
{
    public interface IEventsRepository
    {
        IEnumerable<Event> GetEvents(Func<Event, bool> filter);
        Task<int> CreateEventAsync(Event @event);
    }
}
