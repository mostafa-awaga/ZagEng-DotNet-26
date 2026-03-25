using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            //Rule 1
            builder.ToTable("ProductImages", "Shop");

            //Rule 2
            builder.Property(pi => pi.Url)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(pi => pi.AltText)
                   .HasMaxLength(200);

            //Rule 3
            builder.Property(pi => pi.IsPrimary)
                   .HasDefaultValue(false);

            //Rule 4
            builder.HasOne(pi => pi.Product)
                   .WithOne(p => p.ProductImage)
                   //.HasForeignKey(pi => pi.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
