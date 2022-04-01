using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Core.Domain.ProductDomain;
using System;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.ProductService
{
	public interface IProductService
	{
		Task<Product> GetProductById(Guid id);
		Task<Product> GetProductByName(string name);
		Task<Product> UpdateProduct(ProductUpdateDto ProductDto);
		Task<bool> DeleteProduct(Guid id);
		Task<Product> CreateProduct(ProductCreateDto ProductCreateDto);
	}
}
