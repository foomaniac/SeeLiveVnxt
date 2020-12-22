﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeeLive.Infrastructure;

namespace SeeLive.Infrastructure.Migrations
{
    [DbContext(typeof(SeeLiveContext))]
    [Migration("20201222140501_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnName("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("WebAddress")
                        .HasColumnName("WebAddress")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Artists","dbo");
                });

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnName("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("VenueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("Events","dbo");
                });

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.EventListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnName("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnName("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("EventId");

                    b.ToTable("EventListing","dbo");
                });

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnName("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Venues","dbo");
                });

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.Event", b =>
                {
                    b.HasOne("SeeLive.Core.Domain.Entities.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.EventListing", b =>
                {
                    b.HasOne("SeeLive.Core.Domain.Entities.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");

                    b.HasOne("SeeLive.Core.Domain.Entities.Event", null)
                        .WithMany("EventLists")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("SeeLive.Core.Domain.Entities.Venue", b =>
                {
                    b.OwnsOne("SeeLive.Core.Domain.Address", "Address", b1 =>
                        {
                            b1.Property<int>("VenueId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("AddressLine1")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("County")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PostCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("VenueId");

                            b1.ToTable("Venues");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
