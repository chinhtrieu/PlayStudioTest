using GameClub.Infrastructure.Models;

namespace GameClub.Repository.Abstractions
{
    public interface IClubsRepository
    {
        Task<Club> GetClubAsync(int id);
        Task<List<Club>> GetClubsAsync();
        IEnumerable<Club> GetClubs(Func<Club, bool> filter);
        Task<int> CreateClubAsync(Club club);
    }
}
