using System.Collections.Generic;

namespace JWT_NET_5.Application.Consts
{
	public class AllowCoins
	{
		public static List<int> AllowedCoins
		{
			get
			{
				return new List<int>() { 2,5,10,20,50,100 };
			}
		}
	}
}
