using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.AuthModels
{
	public class LoginModel
	{
		[Required]
		public string UserName { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
