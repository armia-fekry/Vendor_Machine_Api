﻿using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.Data.AuthModels
{
	public class UserRegisterModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		[Required, MaxLength(50)]
		public string UserName { get; set; }
	
		[Required, MaxLength(20)]
		public string Role { get; set; }
		public string Password { get; set; }
	}
}
