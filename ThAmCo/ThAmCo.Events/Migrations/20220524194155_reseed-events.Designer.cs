﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Migrations
{
    [DbContext(typeof(EventsDbContext))]
    [Migration("20220524194155_reseed-events")]
    partial class reseedevents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("thamco.events")
                .HasAnnotation("ProductVersion", "3.1.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThAmCo.Events.Data.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Attendance")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "22 Upton Street",
                            Attendance = false,
                            Email = "alexandra@email.com",
                            NameFirst = "Alex",
                            NameLast = "Coates",
                            Phone = 7519,
                            PostCode = "TS13NE"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "21 Some Street",
                            Attendance = false,
                            Email = "David@email.com",
                            NameFirst = "David",
                            NameLast = "Hodson",
                            Phone = 8765,
                            PostCode = "TS52NE"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.EventClass", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTitle = "Wedding",
                            EventType = "WED"
                        },
                        new
                        {
                            EventId = 2,
                            EventDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTitle = "Meeting",
                            EventType = "MET"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.GuestBooking", b =>
                {
                    b.Property<int>("GuestBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("eventClassEventId")
                        .HasColumnType("int");

                    b.HasKey("GuestBookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("eventClassEventId");

                    b.ToTable("GuestBookings");

                    b.HasData(
                        new
                        {
                            GuestBookingId = 1,
                            CustomerId = 1,
                            EventId = 1
                        },
                        new
                        {
                            GuestBookingId = 2,
                            CustomerId = 2,
                            EventId = 2
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FirstAider")
                        .HasColumnType("bit");

                    b.Property<string>("NameFirst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameLast")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StaffId");

                    b.ToTable("Staffs");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            Address = "An Address",
                            Email = "personOne@gmail.com",
                            FirstAider = false,
                            NameFirst = "Person",
                            NameLast = "One",
                            Phone = 0,
                            PostCode = "YO8"
                        },
                        new
                        {
                            StaffId = 2,
                            Address = "A Place",
                            Email = "Human@gmail.com",
                            FirstAider = true,
                            NameFirst = "Human",
                            NameLast = "Two",
                            Phone = 11111,
                            PostCode = "LS1"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staffing", b =>
                {
                    b.Property<int>("StaffingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("StaffId")
                        .HasColumnType("int");

                    b.Property<int?>("eventClassEventId")
                        .HasColumnType("int");

                    b.HasKey("StaffingId");

                    b.HasIndex("StaffId");

                    b.HasIndex("eventClassEventId");

                    b.ToTable("Staffings");

                    b.HasData(
                        new
                        {
                            StaffingId = 1,
                            EventId = 1,
                            StaffId = 1
                        },
                        new
                        {
                            StaffingId = 2,
                            EventId = 2,
                            StaffId = 2
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.GuestBooking", b =>
                {
                    b.HasOne("ThAmCo.Events.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Data.EventClass", "eventClass")
                        .WithMany()
                        .HasForeignKey("eventClassEventId");
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staffing", b =>
                {
                    b.HasOne("ThAmCo.Events.Data.Staff", "staff")
                        .WithMany()
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Data.EventClass", "eventClass")
                        .WithMany()
                        .HasForeignKey("eventClassEventId");
                });
#pragma warning restore 612, 618
        }
    }
}