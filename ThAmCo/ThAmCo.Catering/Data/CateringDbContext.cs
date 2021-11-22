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



            // Adding seed data to the tables //

            if (_hostEnv != null && _hostEnv.IsDevelopment())
            {
                builder.Entity<FoodItem>()
                    .HasData(
                    new FoodItem { FoodItemId = 1, Description = "Fish", UnitPrice = 3.50f },
                    new FoodItem { FoodItemId = 2, Description = "Chips", UnitPrice = 1.20f }
                    );

                builder.Entity<Menu>()
                    .HasData(
                    new Menu { MenuId = 1, MenuName = "Dinner"},
                    new Menu { MenuId = 2, MenuName = "Lunch"}
                    );

                builder.Entity<MenuFoodItem>()
                    .HasData(
                    new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                    new MenuFoodItem { MenuId = 2, FoodItemId = 2 }
                    );

                builder.Entity<FoodBooking>()
                    .HasData(
                    new FoodBooking { ClientReferenceId = 1, FoodBookingId = 1, MenuId = 1, NumberOfGuests = 1 },
                    new FoodBooking { ClientReferenceId = 2, FoodBookingId = 2, MenuId = 2, NumberOfGuests = 2 }
                    );
            }



        }

    }
}
