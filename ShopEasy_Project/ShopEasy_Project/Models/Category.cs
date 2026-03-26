using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShopEasy_Project.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String? Name { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; } 
        public string? InternalNotes { get; set; }

        // Navigation property
        public Category? ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
