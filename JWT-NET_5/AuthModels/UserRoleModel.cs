using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.AuthModels
{
	public class UserRoleModel
	{
		[Required]
		public string UserId { get; set; }
		[Required]
		public string Role { get; set; }
	}
}
