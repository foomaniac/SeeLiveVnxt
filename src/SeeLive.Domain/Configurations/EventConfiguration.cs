using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeeLive.Domain.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(ev => ev.Id)
                .IsRequired();
            
           builder.HasOne(e => e.Venue);

            builder.Property(ev => ev.Name)
                .IsRequired();

            builder.Property(ev => ev.Bio)
                .IsRequired(false);

        }
    }
}
