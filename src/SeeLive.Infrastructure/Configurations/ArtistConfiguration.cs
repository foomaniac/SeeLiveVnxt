using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Domain.Models;

namespace SeeLive.Infrastructure.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artists", SeeLiveContext.DEFAULT_SCHEMA);

            builder.HasKey(artist => artist.Id);

            builder
                .Property(artist => artist.Id)
                .HasColumnName(nameof(Artist.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(artist => artist.Name)
                .HasColumnName(nameof(Artist.Name))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(artist => artist.Bio)
                .HasColumnName(nameof(Artist.Bio))
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(artist => artist.WebAddress)
                .HasColumnName(nameof(Artist.WebAddress))
                .HasColumnType("nvarchar(256)")
                .IsRequired(false);

        }
    }
}
