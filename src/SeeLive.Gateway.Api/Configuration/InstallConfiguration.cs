namespace SeeLive.Gateway.Api.Configuration
{
    public static class InstallConfiguration
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            //Add Ocelot Gateway Json Config file
            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("ocelot.json")
                .AddEnvironmentVariables();

        }
    }
}
