using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Persistance.Configurations
{
    public static class DependencyInjectionRegister
    {
        public static IServiceCollection AddPersistance(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddDbContext<SeeLiveContext, SeeLiveContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("SeeLiveContext");
                options.UseSqlServer(connectionString);
            });

            return @this;
        }
    }
}
