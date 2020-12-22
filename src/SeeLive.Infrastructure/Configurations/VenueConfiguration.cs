using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Core.Domain;
using SeeLive.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Configurations
{
    public class VenueConfiguration : IEntityTypeConfiguration<Venue>
    {
        public void Configure(EntityTypeBuilder<Venue> builder)
        {
            builder.ToTable("Venues", SeeLiveContext.DEFAULT_SCHEMA);

            builder.HasKey(venue => venue.Id);            

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(Venue.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(venue => venue.Name)
                .HasColumnName(nameof(Venue.Name))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(venue => venue.Bio)
                .HasColumnName(nameof(Venue.Bio))
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            //Address value object persisted as owned entity type supported since EF Core 2.0
            builder.OwnsOne(o => o.Address, a =>
            {
                a.WithOwner();
            });


        }
    }
}
