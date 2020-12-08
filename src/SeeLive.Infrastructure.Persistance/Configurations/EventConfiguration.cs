using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Core.Domain;
using SeeLive.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Persistance.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(ev => ev.Id);

            builder
                .Property(e => e.Id)
                .HasColumnName(nameof(IEntity<int>.Id))
                .HasColumnType("int")
                .IsRequired();

            builder.Property(ev => ev.Name)
                .HasColumnName(nameof(Venue.Name))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(ev => ev.Bio)
                .HasColumnName(nameof(Venue.Bio))
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.Property(ev => ev.AddressLine1)
                .HasColumnName(nameof(IAddressEntity.AddressLine1))
                .HasColumnType("nvarchar(256)")
                .IsRequired();


            builder.Property(ev => ev.AddressLine2)
                .HasColumnName(nameof(IAddressEntity.AddressLine2))
                .HasColumnType("nvarchar(256)")
                .IsRequired(false);


            builder.Property(ev => ev.AddressLine3)
                .HasColumnName(nameof(IAddressEntity.AddressLine3))
                .HasColumnType("nvarchar(256)")
                .IsRequired(false);


            builder.Property(ev => ev.PostCode)
                .HasColumnName(nameof(IAddressEntity.PostCode))
                .HasColumnType("nvarchar(20)")
                .IsRequired();

            builder.Property(ev => ev.City)
                .HasColumnName(nameof(IAddressEntity.City))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(ev => ev.County)
                .HasColumnName(nameof(IAddressEntity.County))
                .HasColumnType("nvarchar(256)")
                .IsRequired(false);


            builder.Property(ev => ev.Country)
                .HasColumnName(nameof(IAddressEntity.Country))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

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

            builder.Property(ev => ev.CreatedByUser)
                .HasColumnName(nameof(Venue.CreatedByUser))
                .HasColumnType("nvarchar(256)")
                .IsRequired();
        }
    }
}
