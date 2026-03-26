using Microsoft.EntityFrameworkCore;
using ShopEasy_Project.Data;
using ShopEasy_Project.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

await using var context = new AppDbContext();

Console.WriteLine("  Checking seed data...");
await DataSeeder.SeedAsync(context);

