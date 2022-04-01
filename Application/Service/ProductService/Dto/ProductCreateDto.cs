using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.ProductService.Dto
{
	public class ProductCreateDto
	{
		[Required,MaxLength(25)]
		public string ProductName { get; set; }
		[Required]
		public int Amount { get; set; }
		[Required]
		public int Cost { get; set; }
		[Required]
		public Guid UserId { get; set; }
	}
}
