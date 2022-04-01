using System.Collections.Generic;

namespace JWT_NET_5.Common.Consts
{
	public  class AllowedCoins
	{
		private static readonly List<int> AvailableCoins = new List<int> { 5, 10, 20, 50, 100 };
		 public static List<int> GetAvailableCoins() => AvailableCoins;
	}
}
