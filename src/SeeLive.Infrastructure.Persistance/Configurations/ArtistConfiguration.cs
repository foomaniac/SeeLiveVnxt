using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Core.Domain;
using SeeLive.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Persistance.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(artist => artist.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(IEntity<int>.Id))
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


            builder.Property(artist => artist.City)
                .HasColumnName(nameof(Artist.City))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(artist => artist.WebAddress)
                .HasColumnName(nameof(Artist.WebAddress))
                .HasColumnType("nvarchar(256)")
                .IsRequired(false);

            builder
                .Property(e => e.DateCreated)
                .HasColumnName(nameof(IEntity<int>.DateCreated))
                .HasColumnType("datetime2")
                .IsRequired();

            builder
                .Property(e => e.DateModified)
                .HasColumnName(nameof(IEntity<int>.DateModified))
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder
                .Property(e => e.DateArchived)
                .HasColumnName(nameof(IEntity<int>.DateArchived))
                .HasColumnType("datetime2")
                .IsRequired(false);

            builder.Property(artist => artist.CreatedByUser)
                .HasColumnName(nameof(Artist.CreatedByUser))
                .HasColumnType("nvarchar(256)")
                .IsRequired();
        }
    }
}
