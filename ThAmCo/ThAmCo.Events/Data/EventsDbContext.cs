using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ThAmCo.Events.Data
{
    public class EventsDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EventClass> Events { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Staffing> Staffings { get; set;  }


        private readonly IHostEnvironment _hostEnv;

        public EventsDbContext()
        {

        }

        public EventsDbContext(DbContextOptions<EventsDbContext> options,
                      IHostEnvironment env) : base(options)
        {
            _hostEnv = env;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("thamco.events");

            // Setting the primary keys on the tables //

            builder.Entity<Customer>()
                    .HasKey(c => new { c.CustomerId });

            builder.Entity<EventClass>()
                .HasKey(e => new { e.EventId });

            builder.Entity<EventClass>()
                .HasMany(e => e.Bookings);

            builder.Entity<EventClass>()
                .HasMany(e => e.Staffing);

            builder.Entity<GuestBooking>()
                .HasKey(g => new { g.GuestBookingId });

            builder.Entity<GuestBooking>()
                .HasOne(g => g.eventClass)
                .WithMany()
                .HasForeignKey(g => g.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Staff>()
                .HasKey(s => new { s.StaffId});

            builder.Entity<Staff>()
                .HasMany(s => s.staffing);

            builder.Entity<Staffing>()
                .HasKey(s => new { s.StaffingId });

            builder.Entity<Staffing>()
                .HasOne(s => s.eventClass)
                .WithMany()
                .HasForeignKey(s => s.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Adding seed data to the tables //

            if (_hostEnv != null && _hostEnv.IsDevelopment())
            {
                builder.Entity<Customer>()
                    .HasData(
                    new Customer { CustomerId = 1, NameFirst = "Alex", NameLast = "Coates", Phone = 07519, Email = "alexandra@email.com", Address = "22 Upton Street", PostCode = "TS13NE"},
                    new Customer { CustomerId = 2, NameFirst = "David", NameLast = "Hodson", Phone = 08765, Email = "David@email.com", Address = "21 Some Street", PostCode = "TS52NE" }
                    );

                builder.Entity<EventClass>()
                    .HasData(
                    new EventClass { EventId = 1, EventType = "WED", EventTitle = "Wedding" },
                    new EventClass { EventId = 2, EventType = "MET", EventTitle = "Meeting"}
                    );

                builder.Entity<GuestBooking>()
                    .HasData(
                    new GuestBooking { GuestBookingId = 1, CustomerId = 1, EventId = 1 },
                    new GuestBooking { GuestBookingId = 2, CustomerId = 2, EventId = 2 }
                    );

                builder.Entity<Staff>()
                    .HasData(
                    new Staff { StaffId = 1, NameFirst = "Person", NameLast = "One", Phone = 00000, Address = "An Address", PostCode = "YO8", Email = "personOne@gmail.com", FirstAider = false },
                    new Staff { StaffId = 2, NameFirst = "Human", NameLast = "Two", Phone = 011111, Address = "A Place", PostCode = "LS1", Email = "Human@gmail.com", FirstAider = true }
                    );

                builder.Entity<Staffing>()
                    .HasData(
                    new Staffing { StaffingId = 1, EventId = 1, StaffId = 1 },
                    new Staffing { StaffingId = 2, EventId = 2, StaffId = 2 }
                    );
            }


        }

    }
}
