using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PublicLibrary.Models
{
    public static class Validation
    {
        public static bool IsValid(this IValidatable validatableObject)
        {
            var context = new ValidationContext(validatableObject, null, null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(validatableObject, context, results, true);
        }
    }
}
