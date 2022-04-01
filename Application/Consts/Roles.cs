using System.Collections.Generic;

namespace JWT_NET_5.Application.Consts
{
	public class SysRoles
	{
		public static List<string> SystemRoles {
			get
			{
				return new List<string>() { "Seller", "Buyer" };
			}
		}
	}
}
