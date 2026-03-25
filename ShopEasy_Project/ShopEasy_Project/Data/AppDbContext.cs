using Microsoft.EntityFrameworkCore;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ShopEasy_Project.Data
{
    public class AppDbContext : DbContext 
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<ProductTag> ProductTags => Set<ProductTag>();
        public DbSet<ProductImage> ProductImages => Set<ProductImage>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<Review> Reviews => Set<Review>();
        public DbSet<Discount> Discounts => Set<Discount>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KC8Q2AH; Database=ShopEasy_Project; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("DiscountSeq", schema: "shop")
                .StartsAt(1000)
                .IncrementsBy(1);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
