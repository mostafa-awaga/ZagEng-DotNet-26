using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string? Url { get; set; }
        public string? AltText { get; set; }
        public bool IsPrimary { get; set; }

        // Navigation property
        public Product Product { get; set; } = null!;
    }
}
