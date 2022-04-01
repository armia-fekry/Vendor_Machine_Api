using System;

namespace JWT_NET_5.Application.Service.ProductService.Dto
{
	internal class ProductDto:ProductCreateDto
	{
		public Guid Id { get; set; }
	}
}
