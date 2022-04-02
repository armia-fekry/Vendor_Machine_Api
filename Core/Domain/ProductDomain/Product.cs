using JWT_NET_5.Common.Model;
using JWT_NET_5.Core.Domain.Shared;
using JWT_NET_5.Core.Domain.UserDomain;
using System;

namespace JWT_NET_5.Core.Domain.ProductDomain
{
	public class Product:BaseEntity
	{
		public string ProductName { get; set; }
		public int Amount { get; set; }
		public double Cost { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }

		public Product()
		{

		}
		public Product(Guid id, string productName
			, int amount, double cost, Guid userId) : this()
		{
			AssertionConcern.AssertionAgainstNotNull(id, "Inavlid product Id");
			AssertionConcern.AssertionAgainstNotNullOrEmplty(productName, "Invalid Product Name");
			AssertionConcern.AssertionAgainstNotNull(amount, "Invalid Amount");
			AssertionConcern.AssertionAgainstNotNull(amount, "Invalid Cost");
			AssertionConcern.AssertionAgainstNotNull(userId, "Invalid User Id");
			Id=id;	
			ProductName=productName;
			Amount=amount;
			Cost=cost;
			UserId=userId;
		}

		public static Product Create(Guid id, string productName
			, int amount, double cost, Guid userId)
		{
			return new(id, productName, amount, cost, userId);
		}


		private void SetProductName(string productName)
		{
			ProductName = productName;
		}
		private void SetAmount(int amount)
		{
			Amount = amount;
		}
		private void SetCost(int cost)
		{
			Cost = cost;
		}
		private void SetUserId(Guid userId)
		{
			UserId = userId;
		}
	}
}
