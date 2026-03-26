using Microsoft.EntityFrameworkCore;
using ShopEasy_Project.Data;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopEasy_Project.Services
{
    public static class DataSeeder
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task SeedAsync(AppDbContext context)
        {
            if (await context.Customers.AnyAsync())
            {
                Console.WriteLine(" Data already exists — skipping.");
                return;
            }

            Console.WriteLine(" Starting data seeding...");
            await using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                // 1. Categories
                var categories = Load<Category>("categories.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Categories ON");
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Categories OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {categories.Count} categories seeded.");

                // 2. Products
                var availableCategoryIds = await context.Categories.Select(c => c.CategoryId).ToListAsync();
                var allProducts = Load<Product>("products.json");
                var validProducts = allProducts.Where(p => availableCategoryIds.Contains(p.CategoryId)).ToList();

                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Products ON");
                await context.Products.AddRangeAsync(validProducts);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Products OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {validProducts.Count} products seeded (Skipped {allProducts.Count - validProducts.Count} invalid products).");

                // 3. Customers
                var customers = Load<Customer>("customers.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Customers ON");
                await context.Customers.AddRangeAsync(customers);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Customers OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {customers.Count} customers seeded.");

                // 4. CustomerProfiles
                var profiles = Load<CustomerProfile>("customerProfiles.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.CustomerProfiles ON");
                await context.CustomerProfiles.AddRangeAsync(profiles);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.CustomerProfiles OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {profiles.Count} customer profiles seeded.");

                // 5. Tags
                var tags = Load<Tag>("tags.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Tags ON");
                await context.Tags.AddRangeAsync(tags);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Tags OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {tags.Count} tags seeded.");

                // 6. ProductTags
                var productTags = Load<ProductTag>("productTags.json");
                await context.ProductTags.AddRangeAsync(productTags);
                await context.SaveChangesAsync();
                context.ChangeTracker.Clear();
                Console.WriteLine($" {productTags.Count} product tags seeded.");

                // 7. Orders
                var orders = Load<Order>("orders.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Orders ON");
                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Orders OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {orders.Count} orders seeded.");

                // 8. OrderItems
                var orderItems = Load<OrderItem>("orderItems.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.OrderItems ON");
                await context.OrderItems.AddRangeAsync(orderItems);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.OrderItems OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {orderItems.Count} order items seeded.");

                // 9. Payments
                var payments = Load<Payment>("payments.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Payments ON");
                await context.Payments.AddRangeAsync(payments);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Payments OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {payments.Count} payments seeded.");

                // 10. Reviews
                var reviews = Load<Review>("reviews.json");
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Reviews ON");
                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
                await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT shop.Reviews OFF");
                context.ChangeTracker.Clear();
                Console.WriteLine($" {reviews.Count} reviews seeded.");

                // 11. Discounts
                var discounts = Load<Discount>("discounts.json");
                await context.Discounts.AddRangeAsync(discounts);
                await context.SaveChangesAsync();
                context.ChangeTracker.Clear();
                Console.WriteLine($" {discounts.Count} discounts seeded.");

                await transaction.CommitAsync();
                Console.WriteLine(" All data seeded successfully!\n");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($" Seeding failed: {ex.Message}");
                throw;
            }
        }

        private static List<T> Load<T>(string fileName)
        {
            var basePath = AppContext.BaseDirectory;
            var filePath = Path.Combine(basePath, "Models", "JsonData", fileName);
            if (!File.Exists(filePath)) throw new FileNotFoundException($"Seed file not found: {filePath}");
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json, _jsonOptions) ?? new List<T>();
        }
    }
}