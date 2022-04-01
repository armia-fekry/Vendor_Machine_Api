using System;
using System.ComponentModel.DataAnnotations;

namespace JWT_NET_5.Application.Service.ProductService.Dto
{
	public class ProductUpdateDto
    {
		[Required, MaxLength(25)]
		public string ProductName { get; set; }
		[Required]
		public int Amount { get; set; }
		[Required]
		public int Cost { get; set; }
		[Required]
		public Guid UserId { get; set; }
	}
}
