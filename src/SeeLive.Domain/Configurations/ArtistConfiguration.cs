using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeeLive.Domain.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .Property(artist => artist.Id)
                .IsRequired();

            builder.Property(artist => artist.Name)
                .IsRequired();

            builder.Property(artist => artist.Bio)
                .IsRequired(false);

            builder.Property(artist => artist.WebAddress)
                .IsRequired(false);

        }
    }
}
