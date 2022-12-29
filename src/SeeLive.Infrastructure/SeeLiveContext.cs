using Microsoft.EntityFrameworkCore;
using SeeLive.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SeeLive.Domain
{
    public class SeeLiveContext : DbContext, IUnitOfWork
    {
        public SeeLiveContext(DbContextOptions<SeeLiveContext> options) : base(options)
        { 
        }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeeLiveContext).Assembly);            
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<EventListing> EventListings { get; set; }
    }
}
