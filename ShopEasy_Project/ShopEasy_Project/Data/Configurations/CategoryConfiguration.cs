using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Rule 1
            builder.ToTable("Categories", "Shop");

            //Rule 2
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Slug)
                   .IsRequired()
                   .HasMaxLength(100);

            //Rule 3
            builder.HasIndex(c => c.Slug)
                   .IsUnique()
                   .HasDatabaseName("IX_Categories_Slug");

            //Rule 4
            builder.Ignore(c => c.InternalNotes);

            //Rule 5
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(c => c.ParentCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
