using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Common.Attribute;
using JWT_NET_5.Core.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.UserService.Dto
{
    public class UserCreateDto
    {
		[Required,MaxLength(32)]
		public string UserName { get; set; }
		[Required, MaxLength(32)]
		public string Password { get; set; }
		[ValidateCoin]
		public int Deposit { get; set; }
		[Required]
		public RoleEnum Role { get; set; }
		public ICollection<ProductDto> Products { get; set; }
	}
}
