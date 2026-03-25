using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Rule 1
            builder.ToTable("Products", "Shop");

            //Rule 2
            builder.Property(p => p.Price)
                   .HasColumnType("decimal(18,2)");

            //Rule 3
            builder.Property(p => p.IsActive)
                   .HasDefaultValue(true);

            //Rule 4
            builder.Property(p => p.DisplayName)
                   .HasComputedColumnSql("[Name] + ' (' + [SKU] + ')'");

            //Rule 5
            builder.HasQueryFilter(p => p.IsActive);

            //Rule 6
            builder.HasIndex(p => p.SKU)
                   .IsUnique()
                   .HasDatabaseName("IX_Products_SKU");

            builder.HasOne(c => c.Category)
                   .WithMany(p => p.Products)
                   //.HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
