using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SeeLive.Infrastructure.Persistance.Configurations;

namespace SeeLive.Application.Api
{
    public class Startup
    {
         public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistance(Configuration);
          
            services.AddControllers();

            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
           {
               options.Authority = "https://localhost:5000";
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };
           });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SeeLive.Api", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "SeeLive.Api");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                      .RequireAuthorization("SeeLive.Api");
            });
        }
    }
}
