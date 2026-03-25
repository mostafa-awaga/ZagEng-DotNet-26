using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ShopEasy_Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ShopEasy_Project.Data.Configurations
{
    public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
    {
        public void Configure(EntityTypeBuilder<CustomerProfile> builder)
        {
            //Rule 1
            builder.ToTable("CustomerProfiles" , "Shop");

            //Rule 2
            builder.Property(cp => cp.Address)
                   .HasMaxLength(300);

            builder.Property(cp => cp.City)
                   .HasMaxLength(200);

            builder.Property(cp => cp.PostalCode)
                   .HasMaxLength(20);

            //Rule 3
            builder.Property(cp => cp.NationalId)
                   .HasMaxLength(50)
                   .HasColumnType("nchar(14)");

            //Rule 4, 5
            builder.HasOne(cp => cp.Customer)
                   .WithOne(c => c.CustomerProfile)
                   .HasForeignKey<CustomerProfile>(cp => cp.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
