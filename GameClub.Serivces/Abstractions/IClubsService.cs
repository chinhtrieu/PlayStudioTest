using GameClub.Infrastructure;
using GameClub.Infrastructure.Models;

namespace GameClub.Serivces.Abstractions
{
    public interface IClubsService
    {
        Task<List<Club>> GetClubs();
        List<Club> SearchClubs(SearchClubRequest request);
        Task<Result> CreateClubAsync(Club club);
        List<Event> GetClubEvents(int clubId);
        Task<Result> CreateClubEventAsync(Event @event);
    }
}
