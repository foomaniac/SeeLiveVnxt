using System;
using Microsoft.EntityFrameworkCore;
using SeeLive.Core.Domain;
namespace SeeLive.Infrastructure.Persistance
{
    public class SeeLiveContext : DbContext
    {
        public DbSet<Artist> Artists {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasKey(artist => artist.Id);
                
            modelBuilder.Entity<Artist>()                
                .Property(artist => artist.Name)
                .IsRequired();
        }
    }
}
