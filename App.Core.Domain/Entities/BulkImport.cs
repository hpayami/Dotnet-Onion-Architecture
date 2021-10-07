using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Core.Domain.Entities
{
    public class BulkImport : IValidatableObject
    {
        [Key]
        public int BulkImportId { get; set; }

        [Required]
        [MaxLength(256)]
        public string Filename { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}