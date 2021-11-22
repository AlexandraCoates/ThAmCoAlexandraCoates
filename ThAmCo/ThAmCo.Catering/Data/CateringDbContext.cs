using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }

        private readonly IHostEnvironment _hostEnv;

        public CateringDbContext(DbContextOptions<CateringDbContext> options,
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
            builder.HasDefaultSchema("thamco.catering");

            // Setting the primary keys on the tables //

            builder.Entity<FoodBooking>()
                    .HasKey(f => new { f.FoodBookingId });

            builder.Entity<FoodItem>()
                .HasKey(i => new { i.FoodItemId });

            builder.Entity<Menu>()
                .HasKey(m => new { m.MenuId });

            builder.Entity<MenuFoodItem>()
                .HasKey(m => new { m.MenuId, m.FoodItemId });



            // Setting up relationships between the tables //




        }

    }
}
