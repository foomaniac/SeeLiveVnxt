using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SeeLive.Domain.AggregatesModel.ArtistAggregate;
using SeeLive.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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

            @this.AddScoped<IArtistRepository,ArtistRepository>();
            
            return @this;
        }
    }
}
