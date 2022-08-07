using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace SeeLive.Gateway.Api.Configuration
{
    public static class InstallOcelot
    {
        public static void AddOcelotService(this IServiceCollection services)
        {
            services.AddOcelot();
        }

        public static void AddOcelotMiddleware(this WebApplication app)
        {
            app.UseOcelot().Wait();
        }
    }
}
