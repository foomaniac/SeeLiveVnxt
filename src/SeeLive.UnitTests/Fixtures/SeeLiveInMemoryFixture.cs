using Microsoft.EntityFrameworkCore;
using SeeLive.Domain;
using System;
using SeeLive.Domain.Entities;
using SeeLive.Domain.Features.Venues;

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

        public async void SeedUpdateEventTestData()
        {
            Venue testVenue = new Venue("Update Test Venue","Test Venue",new Address("","","","",""));
            await SeeLiveContext.Venues.AddAsync(testVenue);
            await SeeLiveContext.SaveEntitiesAsync();
        }

        public void Dispose()
        {
            SeeLiveContext.Dispose();
        }
    }
}
