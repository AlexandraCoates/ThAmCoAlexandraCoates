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

            builder.Entity<GuestBooking>()
                .HasKey(g => new { g.GuestBookingId });

            builder.Entity<Staff>()
                .HasKey(s => new { s.StaffId});

            builder.Entity<Staffing>()
                .HasKey(s => new { s.StaffingId });




        }

    }
}
