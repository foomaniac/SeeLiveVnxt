using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using SeeLive.Abstractions;
using SeeLive.Domain;
using SeeLive.Domain.Features.Events;
using SeeLive.Infrastructure.Configurations;
using SeeLive.Infrastructure.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SeeLive.Infrastructure"));                
            });

            @this.AddTransient<IArtistsRepository, ArtistRepository>();
            @this.AddTransient<IEventsRepository, EventsRepository>();

            return @this;
        }
    }
}
