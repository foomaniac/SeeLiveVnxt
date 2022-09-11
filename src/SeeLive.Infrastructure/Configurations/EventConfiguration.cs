﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeeLive.Core.Domain;
using SeeLive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeeLive.Infrastructure.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Events", SeeLiveContext.DEFAULT_SCHEMA);

            builder.HasKey(ev => ev.Id);

            builder
                .Property(ev => ev.Id)
                .HasColumnName(nameof(Event.Id))
                .HasColumnType("int")
                .IsRequired();
            
           builder
             .HasOne(e => e.Venue);

            builder.Property(ev => ev.Name)
                .HasColumnName(nameof(Venue.Name))
                .HasColumnType("nvarchar(256)")
                .IsRequired();

            builder.Property(ev => ev.Bio)
                .HasColumnName(nameof(Venue.Bio))
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

        }
    }
}
