using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Core.Domain;
using SeeLive.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Persistance.Configurations
{
    public class EventListingConfiguration : IEntityTypeConfiguration<EventListing>
    {
        public void Configure(EntityTypeBuilder<EventListing> builder)
        {
            builder.HasKey(eventListing => eventListing.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(IEntity<int>.Id))
                .HasColumnType("int")
                .IsRequired();

            builder
             .HasOne(e => e.Event)
             .WithMany(e => e.EventListings)
             .HasForeignKey(e => e.EventId)
             .IsRequired();

            builder
             .HasOne(e => e.Artist)
             .WithMany(e => e.EventListings)
             .HasForeignKey(e => e.ArtistId)
             .IsRequired();

            builder
             .HasOne(e => e.Venue)
             .WithMany(e => e.EventListings)
             .HasForeignKey(e => e.VenueId)
             .IsRequired();

            builder
                 .Property(e => e.StartTime)
                 .HasColumnName(nameof(EventListing.StartTime))
                 .HasColumnType("datetime2")
                 .IsRequired(false);

            builder
                 .Property(e => e.EndTime)
                 .HasColumnName(nameof(EventListing.EndTime))
                 .HasColumnType("datetime2")
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

            builder.Property(eventListing => eventListing.CreatedByUser)
                .HasColumnName(nameof(Artist.CreatedByUser))
                .HasColumnType("nvarchar(256)")
                .IsRequired();
        }
    }
}
