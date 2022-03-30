using JWT_NET_5.Core.Domain.Shared;
using JWT_NET_5.Core.Domain.UserDomain;
using System;

namespace JWT_NET_5.Core.Domain.ProductDomain
{
	public class Product:BaseEntity
	{
		//amountAvailable, cost, productName and
		//sellerId fields
		public string ProductName { get; set; }
		public int Amount { get; set; }
		public double Cost { get; set; }
		public Guid UserId { get; set; }
		public User User { get; set; }

	}
}
