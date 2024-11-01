using GameClub.Infrastructure.Models;
using GameClub.Repository.Abstractions;
using GameClub.Repository.Data;
using Microsoft.EntityFrameworkCore;
namespace GameClub.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EventsRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IEnumerable<Event> GetEvents(Func<Event, bool> filter)
        {
            return _dbContext.Events.Where(filter);
        }

        public async Task<int> CreateEventAsync(Event @event)
        {
            _dbContext.Events.Add(@event);
            return await _dbContext.SaveChangesAsync();

        }


    }
}
