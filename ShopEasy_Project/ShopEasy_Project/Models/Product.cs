using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? SKU { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public string? DisplayName { get; set; }

        // Navigation properties
        //public Order Order { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public ProductImage ProductImage { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
