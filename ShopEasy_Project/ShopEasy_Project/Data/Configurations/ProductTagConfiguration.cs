using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            //Rule 1
            builder.ToTable("ProductTags", "Shop");

            //Rule 2
            builder.HasKey(pt => new { pt.ProductId, pt.TagId });

            //Rule 3
            builder.HasOne(pt => pt.Product)
                   .WithMany(p => p.ProductTags)
                   .HasForeignKey(pt => pt.ProductId);

            //Rule 4
            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.ProductTags)
                   .HasForeignKey(pt => pt.TagId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
