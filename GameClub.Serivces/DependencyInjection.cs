

using GameClub.Serivces.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GameClub.Serivces
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IClubsService, ClubsService>();
            services.RegisterRepository();
            return services;
        }

    }
}
