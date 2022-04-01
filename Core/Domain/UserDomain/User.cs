using JWT_NET_5.Common.Model;
using JWT_NET_5.Core.Domain.Enum;
using JWT_NET_5.Core.Domain.ProductDomain;
using JWT_NET_5.Core.Domain.Shared;
using System;
using System.Collections.Generic;

namespace JWT_NET_5.Core.Domain.UserDomain
{
	public class User:BaseEntity
    {
		#region Properties
		public string UserName { get; set; }
		public string Password { get; set; }
		public int Deposit { get; set; }
		public RoleEnum Role { get; set; }
		public ICollection<Product> Products { get; set; }
		#endregion

		public User()
		{

		}
		public User(Guid id,string userName
			,string password,RoleEnum role
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
			SetProducts(products);
		}
		public static User Create(Guid id, string userName
			, string password, RoleEnum role
			, List<Product> products)
		{
			return new(id, userName, password,role,products);
		}
		private void SetProducts(List<Product> products)
		{
			if (Role != RoleEnum.Seller)
				throw new Exception("Can not add products");
			Products = products;
		}
	}
}
