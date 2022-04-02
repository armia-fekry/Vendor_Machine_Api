using JWT_NET_5.Application.Consts;
using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Common.Attribute;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.Application.Service.UserService.Dto
{
	public class UserCreateDto
    {
		[Required,MaxLength(32)]
		public string UserName { get; set; }
		[Required, MaxLength(32)]
		public string Password { get; set; }
		[ValidateCoin]
		public double Deposit { get; set; }
		[Required]
		public string Role {
			get 
			{ 
				return Role;
			}
			set 
			{
				if (Role.Contains(value))
					throw new System
						.Exception($"Valid Roles Only Is {string.Join(',', SysRoles.SystemRoles.ToArray())}");
				else
					Role = value;
			} 
		}
		
	}
}
