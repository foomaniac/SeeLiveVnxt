using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeeLive.Domain.Configurations
{
    public class EventListingConfiguration : IEntityTypeConfiguration<EventListing>
    {
        public void Configure(EntityTypeBuilder<EventListing> builder)
        {
            builder.Property(e => e.Id)
                       .IsRequired();

            builder.HasOne(e => e.Artist);

            builder.Property(e => e.StartTime)
                  .IsRequired();

            builder.Property(e => e.EndTime)
                 .IsRequired();

        }
    }
}
