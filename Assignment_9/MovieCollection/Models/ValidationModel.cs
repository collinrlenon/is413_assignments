using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class ValidationModel : ValidationAttribute
    {
        protected override ValidationResult IsValid(object val, ValidationContext valContext)
        {
            string msg = string.Empty;

            if (Convert.ToString(val).ToLower() == "independence day")
            {
                msg = "Sorry, we cannot add Independence Day. It is not as good as Rocky IV";
                return new ValidationResult(msg);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

