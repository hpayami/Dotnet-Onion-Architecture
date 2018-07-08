using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
