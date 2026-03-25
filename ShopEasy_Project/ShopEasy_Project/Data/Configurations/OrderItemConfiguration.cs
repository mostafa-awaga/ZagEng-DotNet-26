using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            //Rule 1
            builder.ToTable("OrderItem", "Shop");

            //Rule 2
            builder.Property(oi => oi.UnitPrice)
                   .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            //Rule 3
            builder.HasIndex(oi => new { oi.OrderId, oi.ProductId })
                   .HasDatabaseName("IX_OrderItems_Order_Product");

            //Rule 4
            builder.HasOne(oi => oi.Order)
                   .WithMany(oi => oi.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            //Rule 5
            builder.HasOne(oi => oi.Product)
                   .WithMany(oi => oi.OrderItems)
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
