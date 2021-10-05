using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities
{
    public class Product : IValidatableObject
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(256)]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public bool Discontinued { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (ProductId == 0)
            {
                if (Discontinued == true)
                {
                    errors.Add(new ValidationResult("You cannot add a discontinued product"));
                }
            }

            return errors;
        }
    }
}