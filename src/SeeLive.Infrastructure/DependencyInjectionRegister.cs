using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
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

                Console.WriteLine(connectionString);

                options.UseSqlServer(connectionString);                
            });

            @this.AddTransient<IArtistRepository, ArtistRepository>();

            return @this;
        }
    }
}
