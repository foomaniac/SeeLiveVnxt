using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeeLive.Domain;
using SeeLive.Domain.Features.Artists.Interfaces;
using SeeLive.Domain.Features.Events.Interfaces;
using SeeLive.Infrastructure.Repositories;

namespace SeeLive.Infrastructure
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddPersistance(this IServiceCollection @this, IConfiguration configuration)
        {            
            @this.AddDbContext<SeeLiveContext, SeeLiveContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SeeLiveContext");
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SeeLive.Infrastructure"));                
            });

            @this.AddTransient<IArtistsRepository, ArtistRepository>();
            @this.AddTransient<IEventsRepository, EventsRepository>();
            @this.AddTransient<IVenuesRepository, VenuesRepository>();

            return @this;
        }
    }
}
