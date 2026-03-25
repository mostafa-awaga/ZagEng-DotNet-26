using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class CustomerProfile
    {
        public int CustomerProfileId { get; set; }
        public int CustomerId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? NationalId { get; set; }

        // Navigation property
        public Customer Customer { get; set; } = null!;

    }
}
