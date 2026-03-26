using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class ProductTag
    {
        public int ProductId { get; set; }
        public int TagId { get; set; }

        // Navigation properties
        public Product Product { get; set; } = new Product();
        public Tag Tag { get; set; } = new Tag();
    }
}
