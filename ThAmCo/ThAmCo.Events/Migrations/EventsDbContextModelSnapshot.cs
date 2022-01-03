﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Migrations
{
    [DbContext(typeof(EventsDbContext))]
    partial class EventsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("ThAmCo.Events.Data.EventClass", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
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
                });

            modelBuilder.Entity("ThAmCo.Events.Data.GuestBooking", b =>
                {
                    b.HasOne("ThAmCo.Events.Data.Customer", "customer")
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
