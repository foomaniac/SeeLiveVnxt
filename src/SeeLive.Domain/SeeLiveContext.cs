using Microsoft.EntityFrameworkCore;

namespace SeeLive.Domain
{
    public class SeeLiveContext : DbContext, IUnitOfWork
    {
        private readonly IModelConfiguration modelConfiguration;
        public SeeLiveContext(DbContextOptions<SeeLiveContext> options, IModelConfiguration modelConfiguration) : base(options)
        {
            this.modelConfiguration = modelConfiguration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeeLiveContext).Assembly);
            modelConfiguration.ConfigureModel(modelBuilder);
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
