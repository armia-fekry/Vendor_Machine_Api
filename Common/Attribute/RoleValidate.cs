using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NET_5.Common.Attribute
{
    public class RoleValidate: ValidationAttribute
    {
		
		
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var roles = validationContext.ObjectInstance;
			return ValidationResult.Success;
		}
	}
}
