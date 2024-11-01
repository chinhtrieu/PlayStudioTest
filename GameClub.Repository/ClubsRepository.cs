using GameClub.Infrastructure.Models;
using GameClub.Repository.Abstractions;
using GameClub.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace GameClub.Repository
{
    public class ClubsRepository : IClubsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ClubsRepository()
        {
            _dbContext = new ApplicationDbContext();
        }
        public async Task<List<Club>> GetClubsAsync()        
        {
            return await _dbContext.Clubs.ToListAsync();
        }
        public IEnumerable<Club> GetClubs(Func<Club, bool> filter)
        {
            return _dbContext.Clubs.Where(filter);
        }
        public async Task<Club> GetClubAsync(int id)
        {
            return await _dbContext.Clubs.FirstOrDefaultAsync(m => m.Id == id);
        }
        
        public async Task<int> CreateClubAsync(Club club)
        {
            _dbContext.Clubs.Add(club);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
