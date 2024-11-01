using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameClub.Data.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Club> Clubs { get; }
        DbSet<Event> Events { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
