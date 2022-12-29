using Microsoft.EntityFrameworkCore;
using SeeLive.Domain;
using System;

namespace SeeLive.Api.UnitTests.Fixtures
{
    public class SeeLiveInMemoryFixture : IDisposable
    {
        public SeeLiveContext SeeLiveContext;
        public SeeLiveInMemoryFixture()
        {
            //Configure
            var contextBuilder = new DbContextOptionsBuilder<SeeLiveContext>();
            contextBuilder.UseInMemoryDatabase(databaseName: "PureFlexiblePricingDev");

            //Create Context
            SeeLiveContext = new SeeLiveContext(contextBuilder.Options);
            SeeLiveContext.Database.EnsureDeleted();
            SeeLiveContext.Database.EnsureCreated();

        }
        public void Dispose()
        {
            SeeLiveContext.Dispose();
        }
    }
}
