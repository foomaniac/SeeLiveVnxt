using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using SeeLive.Abstractions;
using SeeLive.Domain;
using SeeLive.Infrastructure.Configurations;
using SeeLive.Infrastructure.Repositories;

namespace SeeLive.Infrastructure
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddPersistance(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
            @this.AddDbContext<SeeLiveContext, SeeLiveContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SeeLiveContext");

                Console.WriteLine(connectionString);

                options.UseSqlServer(connectionString);                
            });

            @this.AddTransient<IArtistsRepository, ArtistRepository>();

            return @this;
        }
    }
}
