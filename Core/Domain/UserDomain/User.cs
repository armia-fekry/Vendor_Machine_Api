using JWT_NET_5.Common.Consts;
using JWT_NET_5.Common.Model;
using JWT_NET_5.Core.Domain.Enum;
using JWT_NET_5.Core.Domain.ProductDomain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JWT_NET_5.Core.Domain.UserDomain
{
	public class User: IdentityUser<Guid>
	{
		#region Properties
		public string Password { get; set; }
		public int Deposit { get; set; }
		public string Role { get; set; }
		public ICollection<Product> Products { get; set; }
		#endregion

		public User()
		{

		}
		public User(Guid id,string userName
			,string password,string role,int coins
			,List<Product> products)
		{
			AssertionConcern.AssertionAgainstNotNull(id, "Invalid User Id");
			AssertionConcern.AssertionAgainstNotNullOrEmplty(userName, "Invalid User Name");
			AssertionConcern.AssertionAgainstNotNullOrEmplty(password, "Invalid User Password");
			AssertionConcern.AssertionAgainstNotNull(role, "Invalid Role");
			
			Id=id;
			UserName=userName;
			Password=password;
			Role=role;
			SetDeposit(coins);
			SetProducts(products);
		}
		public static User Create(Guid id, string userName
			, string password, string role,int coins=0
			, List<Product> products=null)
		{
			return new(id, userName, password,role,coins,products);
		}
		private void SetProducts(List<Product> products)
		{
			if (Role != "Seller")
				throw new Exception("Can not add products");
			Products = products;
		}
		private void SetDeposit(int coins)
		{
			if (AllowedCoins.GetAvailableCoins().Contains(coins))
				throw new Exception($"Cannot add this Coins,Allowed Coins {string.Join(',',AllowedCoins.GetAvailableCoins())}");
			Deposit = coins;
		}

	}
}
