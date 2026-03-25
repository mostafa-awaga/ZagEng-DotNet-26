using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //Rule 1
            builder.ToTable("Tags", "Shop");

            //Rule 2
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            //Rule 3
            builder.HasIndex(p => p.Name)
                   .IsUnique()
                   .HasDatabaseName("IX_Tags_Name");


        }
    }
}
