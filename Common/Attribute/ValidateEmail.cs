using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attribute
{
	public class ValidateEmail: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value.ToString();
            if (string.IsNullOrEmpty(email))
                return new ValidationResult("not valid email");
            var domain = email.Contains('@')
                ? email.Split('@')[1].Trim()
                : email;
            //if (!string.IsNullOrEmpty(domain))
            //{
            //    if (domain.ToLower() != "")
            //        return new ValidationResult("not valid email domain");
            //}
            return ValidationResult.Success;
        }
    }
}
