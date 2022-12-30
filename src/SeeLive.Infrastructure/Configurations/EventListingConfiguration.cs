using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Domain.Features.Events;

namespace SeeLive.Domain.Configurations
{
    public class EventListingConfiguration : IEntityTypeConfiguration<EventListing>
    {
        public void Configure(EntityTypeBuilder<EventListing> builder)
        {
            builder.ToTable("EventListing").HasKey(eventListing => eventListing.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(EventListing.Id))
                .HasColumnType("int");

            builder
                .Property(e => e.StartTime)
                .HasColumnName(nameof(EventListing.StartTime))
                .HasColumnType("datetime2");

            builder
                .Property(e => e.EndTime)
                .HasColumnName(nameof(EventListing.EndTime))
                .HasColumnType("datetime2");
        }
    }
}
