using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? Name { get; set; }

        // Navigation property
        public Product Product { get; set; } = new Product();
        public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
