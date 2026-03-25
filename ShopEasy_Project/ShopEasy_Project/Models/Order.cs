using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; } = "Pending";
        public decimal TotalAmount { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime? ShippedAt { get; set; }

        // Navigation properties
        public Customer Customer { get; set; } = null!;
        public Payment Payment { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
