using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Domain.Features.Events;
using SeeLive.Domain.Features.Venues;

namespace SeeLive.Domain.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events").HasKey(ev => ev.Id);

            builder.Property(ev => ev.Id)
                .HasColumnName(nameof(Event.Id))
                .HasColumnType("int");

            builder.Property(ev => ev.Name)
                .HasColumnName(nameof(Venue.Name))
                .HasColumnType("nvarchar(256)");

            builder.Property(ev => ev.Bio)
                .HasColumnName(nameof(Venue.Bio))
                .HasColumnType("nvarchar(max)");

        }
    }
}
