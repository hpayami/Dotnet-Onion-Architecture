using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Category : IValidatableObject
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
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
