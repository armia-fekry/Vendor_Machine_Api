using AutoMapper;
using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Core.Domain.ProductDomain;

namespace JWT_NET_5.Application.Mapping
{
	public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductDto>();
				
			CreateMap<ProductDto, Product>();
			CreateMap<ProductUpdateDto, Product>();
				
		}
	}
}
