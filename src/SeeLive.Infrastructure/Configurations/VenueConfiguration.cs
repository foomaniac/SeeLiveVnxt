using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Domain.Features.Venues;

namespace SeeLive.Domain.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable("Venues").HasKey(venue => venue.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(Venue.Id))
                .HasColumnType("int");

            builder.Property(venue => venue.Name)
                .HasColumnName(nameof(Venue.Name))
                .HasColumnType("nvarchar(256)");

            builder.Property(venue => venue.Bio)
                .HasColumnName(nameof(Venue.Bio))
                .HasColumnType("nvarchar(max)");

            builder.OwnsOne(venue => venue.Address);

        }
    }
}
