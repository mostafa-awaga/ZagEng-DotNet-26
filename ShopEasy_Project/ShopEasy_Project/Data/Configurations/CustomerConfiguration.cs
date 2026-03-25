using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //Rule 1
            builder.ToTable("Customers","Shop");

            //Rule 2
            builder.HasKey(c => c.CustomerId);
            builder.Property(c => c.CustomerId)
                   .HasColumnName("customer_id");

            //Rule 3
            builder.Property(c => c.FullName)
                   .IsRequired()
                   .HasMaxLength(150)
                   .HasColumnName("full_name")
                   .HasComment("Customer full legal name");

            //Rule 4
            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.HasIndex(c => c.Email)
                   .IsUnique()
                   .HasDatabaseName("IX_Customers_Email");

            //Rule 5
            builder.Property(c => c.PhoneNumber)
                   .HasMaxLength(20);

            //Rule 6
            builder.Property(c => c.CreatAt)
                   .HasDefaultValueSql("GETUTCDATE()");

        }
    }
}
