

using GameClub.Repository;
using GameClub.Repository.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GameClub.Serivces
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped<IClubsRepository, ClubsRepository>();
            services.AddScoped<IEventsRepository, EventsRepository>();
            return services;
        }

    }
}
