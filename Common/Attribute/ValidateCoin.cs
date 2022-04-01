using JWT_NET_5.Common.Consts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.Common.Attribute
{
	public class ValidateCoin: ValidationAttribute
    {
		private static readonly List<int> AvailableCoins = new List<int>{ 5, 10, 20, 50, 100 };
		
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			int coin = 0;
			if (int.TryParse(value.ToString(), out coin) || !AvailableCoins.Contains(coin))
				return new ValidationResult("Only Valid Coins Is 5,10,20,50,100");
			return ValidationResult.Success;
		}
	}
}
