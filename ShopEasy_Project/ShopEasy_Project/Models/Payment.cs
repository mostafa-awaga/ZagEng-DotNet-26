using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; } = "Credit Card";
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } = "Pending";
        public DateTime PaidAt { get; set; }

        // Navigation property
        public Order Order { get; set; } = null!;
    }
}
