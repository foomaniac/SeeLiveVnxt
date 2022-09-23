using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeeLive.Domain.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder
                .Property(e => e.Id)
                .IsRequired();

            builder.Property(venue => venue.Name)
                .IsRequired();

            builder.Property(venue => venue.Bio)
                .IsRequired(false);

            //Address value object persisted as owned entity type supported since EF Core 2.0
            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
            });


        }
    }
}
