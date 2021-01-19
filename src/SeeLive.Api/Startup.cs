using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SeeLive.Infrastructure;
using Newtonsoft.Json;

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
            var assembly = Assembly.GetExecutingAssembly();

            services.AddPersistance(Configuration);
            services.AddMediatR(assembly);           
            services.AddControllers().AddNewtonsoftJson();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SeeLive.Api", policy =>
                {
                    // policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "SeeLive.Api");
                });
            });
           services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
           {
              options.Authority = "http://localhost:5000";
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateAudience = false,                  
              };
              options.RequireHttpsMetadata = false;
           });        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SeeLive API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
