using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            //Rule 1
            builder.ToTable("Discounts", "Shop");

            //Rule 2 ,3
            builder.Property(d => d.DiscountId)
                   .HasDefaultValueSql("NEXT VALUE FOR shop.DiscountSeq");

            //Rule 4
            builder.Property(d => d.Code)
               .IsRequired()
               .HasMaxLength(30);

            builder.HasIndex(d => d.Code)
                   .IsUnique()
                   .HasDatabaseName("IX_Discounts_Code");

            // Rule 5
            builder.Property(d => d.Percentage)
                   .HasColumnType("decimal(5,2)");

            // Rule 6
            builder.Property(d => d.IsActive)
                   .HasDefaultValue(true);

            builder.Property(d => d.MaxUses)
                   .HasDefaultValue(100);

        }
    }
}
