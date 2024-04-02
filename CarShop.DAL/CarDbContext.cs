using CarShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.DAL
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Store)
                .WithMany(s => s.Cars)
                .HasForeignKey(c => c.StoreId);

            // add a few stores
            modelBuilder.Entity<Store>().HasData(
                               new Store { Id = 1, Name = "Toyota of Orlando", Address = "123 Main St", Phone = "407-555-1212" },
                               new Store { Id = 2, Name = "Honda of Orlando", Address = "456 Main St", Phone = "407-555-1213" });

            // seed a few cars
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2019, Price = 15000, StoreId = 1 },
                new Car { Id = 2, Brand = "Toyota", Model = "Camry", Year = 2020, Price = 20000, StoreId = 1 },
                new Car { Id = 3, Brand = "Honda", Model = "Civic", Year = 2018, Price = 14000, StoreId = 2 },
                new Car { Id = 4, Brand = "Honda", Model = "Accord", Year = 2019, Price = 18000, StoreId = 2 });
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
