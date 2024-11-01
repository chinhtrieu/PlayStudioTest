

using GameClub.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Repository.Data
{
    public sealed class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "GameClubDb");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>().HasData(
                new Club
                {
                    Id = 1,
                    Name = "Night club 1",
                    Description = "Open 24/24"
                },
                  new Club
                  {
                      Id = 2,
                      Name = "Night club 2",
                      Description = "Night club 2 description"
                  },
                   new Club
                   {
                       Id = 3,
                       Name = "Night club 3",
                       Description = "Night club 3 description"

                   }
            );
            modelBuilder.Entity<Event>().HasData(
               new Event
               {
                   Id = 1,
                   ClubId = 1,
                   Title = "Open show",
                   StartTime = DateTime.Now,
                   EndTime = DateTime.Now.AddDays(-1),
                   Created = DateTime.Now,
                   Description = "Show on Club 1"

               },
                new Event
                {
                    Id = 2,
                    ClubId = 2,
                    Title = "Close show",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(-1),
                    Created = DateTime.Now,
                    Description = "Show on Club 2"

                }
           );
        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
