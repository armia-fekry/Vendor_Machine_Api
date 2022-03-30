using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.Data.AuthModels
{
	public class UserRegisterModel
	{
		[Required,MaxLength(20)]
		public string FirstName { get; set; }
		[Required, MaxLength(20)]
		public string LastName { get; set; }
		[Required, MaxLength(50)]
		public string UserName { get; set; }
		[Required, MaxLength(256)]
		[ValidateEmail]
		public string Email { get; set; }
		[Required, MaxLength(20)]

		public string Password { get; set; }
	}
}
