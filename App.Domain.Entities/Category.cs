using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace App.Domain.Entities
{
    public class Category : IValidatableObject
    {
        [Key]
        public int CategoryId { get; set; }
        
        [MaxLength(256)]
        public string CategoryName { get; set; }        
        
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            return errors;
        }
    }
}
