using CarRentals.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CarRentals.DAL
{
    public class CarRentalsContext : DbContext
    {
        public CarRentalsContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(c => new { c.Id, c.LicencePlate });
        }
    }
}
