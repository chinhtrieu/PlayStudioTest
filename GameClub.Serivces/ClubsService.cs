using GameClub.Infrastructure;
using GameClub.Infrastructure.Models;
using GameClub.Repository.Abstractions;
using GameClub.Serivces.Abstractions;
using Microsoft.Extensions.Logging;

namespace GameClub.Serivces
{
    public class ClubsService : IClubsService
    {
        private readonly IClubsRepository _clubsRepository;
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogger<ClubsService> _logger;
        public ClubsService(ILogger<ClubsService> logger, IClubsRepository clubsRepository, IEventsRepository eventsRepository)
        {
            _clubsRepository = clubsRepository;
            _eventsRepository = eventsRepository;
            _logger = logger;
        }

        public async Task<List<Club>> GetClubs()
        {
            return await _clubsRepository.GetClubsAsync();
        }

        public List<Club> SearchClubs(SearchClubRequest request)
        {
            var filter = (Club m) => m.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase);

            var result = _clubsRepository.GetClubs(filter);

            return result.Skip(request.PageIndex).Take(request.PageSize).ToList();
        }

        public async Task<Result> CreateClubAsync(Club club)
        {
            if(!IsClubNameUnique(club))
            {
                return new Result(isSuccess: false, new Error("Club.Conflict", "Club name is not unique", ErrorType.Conflict));
            }

            if(await _clubsRepository.CreateClubAsync(club) > 0)
            {
                return new Result(isSuccess: true);
            }
            else
            {
                return new Result(isSuccess: false, new Error("Club.CreateError", "Something wrong happen", ErrorType.Failure));
            }
        }

        public List<Event> GetClubEvents(int clubId)
        {
            return _eventsRepository.GetEvents((Event m) => m.ClubId == clubId).ToList();
        }
        public async Task<Result> CreateClubEventAsync(Event @event)
        {
            var club = await _clubsRepository.GetClubAsync(@event.ClubId);
            if (club == null)
            {
                return new Result(isSuccess: false, new Error("Event.Error", "Club is not exist", ErrorType.Validation));
            }

            if(await _eventsRepository.CreateEventAsync(@event) > 0)
            {
                return new Result(isSuccess: true);
            }
            else
            {
                return new Result(isSuccess: false, new Error("Club.CreateError", "Something wrong happen", ErrorType.Failure));
            }
        }
       

        private bool IsClubNameUnique(Club club)
        {
            var existingClubs = SearchClubs(new SearchClubRequest { Name = club.Name, PageIndex = 0, PageSize = 1 });
            return !existingClubs.Any();
        }


        

    }
}
