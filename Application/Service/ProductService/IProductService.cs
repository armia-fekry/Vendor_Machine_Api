using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Core.Domain.ProductDomain;
using System;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.ProductService
{
	public interface IProductService
	{
		Task<ProductDto> GetProductById(Guid id);
		Task<ProductDto> GetProductByName(string name);
		Task<ProductDto> UpdateProduct(ProductUpdateDto ProductDto);
		Task<bool> DeleteProduct(Guid id);
		Task<ProductDto> CreateProduct(ProductCreateDto ProductCreateDto);
	}
}
