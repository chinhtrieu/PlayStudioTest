using Asp.Versioning;
using GameClub.Infrastructure;
using GameClub.Infrastructure.Models;
using GameClub.Serivces.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GameClub.API.Controllers
{
    [ApiController]

    [Route("api/[controller]")]    
    public class ClubsController : ControllerBase
    {
        private readonly ILogger<ClubsController> _logger;
        private readonly IClubsService _clubsService;
        public ClubsController(ILogger<ClubsController> logger, IClubsService clubsService)
        {
            _logger = logger;
            _clubsService = clubsService;
        }

        [HttpGet]
        // Get all club
        public async Task<IEnumerable<Club>> Get()
        {
            _logger.LogInformation("Get clug adf asfj afoa jflkasjf kolasdf");
            return await _clubsService.GetClubs();
        }

        [HttpGet("search")]
        // Search club
        public IActionResult SearchClubs(SearchClubRequest request)
        {
            return StatusCode((int)HttpStatusCode.OK, _clubsService.SearchClubs(request));
        }


        [HttpPost]
        // Create game club
        public async Task<IActionResult> Post([FromBody] Club club)
        {
            if(!ModelState.IsValid) return  StatusCode((int)HttpStatusCode.BadRequest);

            var createClubResult = await _clubsService.CreateClubAsync(club);

            if (createClubResult.IsSuccess)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, createClubResult.Error);
            }
        }
        [HttpGet]
        [Route("{clubId}/events")]
        // Get events of club by club ID
        public IActionResult GetClubEvents(int clubId)
        {
            return StatusCode((int)HttpStatusCode.OK, _clubsService.GetClubEvents(clubId));
        }

       
        [HttpPost]
        [Route("{clubId}/events")]
        // Create event for club
        public async Task<IActionResult> CreateClubEvent([FromBody]Event @event)
        {
            if (!ModelState.IsValid) return StatusCode((int)HttpStatusCode.BadRequest);


            var createClubResult = await _clubsService.CreateClubEventAsync(@event);

            if (createClubResult.IsSuccess)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, createClubResult.Error);
            }
        }
    }
}
