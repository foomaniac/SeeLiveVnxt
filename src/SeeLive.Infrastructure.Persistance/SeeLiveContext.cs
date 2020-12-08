using System;
using Microsoft.EntityFrameworkCore;
using SeeLive.Core.Domain;
using SeeLive.Core.Domain.Entities;

namespace SeeLive.Infrastructure.Persistance
{
    public class SeeLiveContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "Dev";
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventListing> EventListings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeeLiveContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
