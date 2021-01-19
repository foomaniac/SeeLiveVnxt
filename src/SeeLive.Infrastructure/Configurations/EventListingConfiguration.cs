using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Core.Domain;
using SeeLive.Domain.AggregatesModel.EventAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Configurations
{
    public class EventListingConfiguration : IEntityTypeConfiguration<EventListing>
    {
        public void Configure(EntityTypeBuilder<EventListing> builder)
        {
            builder.ToTable("EventListing", SeeLiveContext.DEFAULT_SCHEMA);

            builder.HasKey(eventListing => eventListing.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(EventListing.Id))
                .HasColumnType("int")
                .IsRequired();

           builder
             .HasOne(e => e.Artist);

           builder
                 .Property(e => e.StartTime)
                 .HasColumnName(nameof(EventListing.StartTime))
                 .HasColumnType("datetime2")
                 .IsRequired();

            builder
                 .Property(e => e.EndTime)
                 .HasColumnName(nameof(EventListing.EndTime))
                 .HasColumnType("datetime2")
                 .IsRequired();

        }
    }
}
