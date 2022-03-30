using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.AuthModels
{
	public class LoginModel
	{
		[Required]
		[ValidateEmail]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
