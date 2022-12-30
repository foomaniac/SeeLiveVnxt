using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SeeLive.Domain.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {

            builder.ToTable("Artists").HasKey(artist => artist.Id);

            builder.Property(artist => artist.Id)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(artist => artist.Name)
                .HasColumnName(nameof(Artist.Name))
                .HasColumnType("nvarchar(256)");

            builder.Property(artist => artist.Bio)
                .HasColumnName(nameof(Artist.Bio))
                .HasColumnType("nvarchar(max)");

            builder.Property(artist => artist.WebAddress)
                .HasColumnName(nameof(Artist.WebAddress))
                .HasColumnType("nvarchar(256)");

        }
    }
}
