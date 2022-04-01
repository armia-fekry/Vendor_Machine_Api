using System;

namespace JWT_NET_5.Application.Service.ProductService.Dto
{
	public class ProductDto:ProductCreateDto
	{
		public Guid Id { get; set; }
	}
}
