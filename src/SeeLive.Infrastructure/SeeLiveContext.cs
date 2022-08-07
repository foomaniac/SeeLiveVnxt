using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeeLive.Domain.AggregatesModel.ArtistAggregate;
using SeeLive.Domain.AggregatesModel.EventAggregate;
using SeeLive.Domain.AggregatesModel.VenueAggregate;
using SeeLive.Domain.Seedwork;

namespace SeeLive.Infrastructure
{
    public class SeeLiveContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventListing> EventListings { get; set; }

        public SeeLiveContext(DbContextOptions<SeeLiveContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeeLiveContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
