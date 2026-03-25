using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //Rule 1
            builder.ToTable("Orders", "Shop");

            //Rule 2
            builder.Property(o => o.Status)
                   .HasConversion<string>()
                   .HasMaxLength(30)
                   .HasDefaultValue("Pending");

            //Rule 3
            builder.Property(o => o.TotalAmount)
                   .HasColumnType("decimal(18,2)");

            //Rule 4
            builder.Property(o => o.PlacedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            //Rule 5
            builder.HasIndex(o => o.Status)
                   .HasFilter("[Status] = 'Pending'")
                   .HasDatabaseName("IX_Orders_PendingStatus");

            //Rule 6
            builder.HasOne(o => o.Customer)
                   .WithMany(o => o.Orders)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
