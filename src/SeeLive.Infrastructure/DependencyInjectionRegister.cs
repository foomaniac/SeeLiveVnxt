using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                options.UseSqlServer("name=ConnectionStrings:SeeLiveContext",
                    x => x.MigrationsAssembly("SeeLive.Infrastructure"));
            });

            return @this;
        }
    }
}
