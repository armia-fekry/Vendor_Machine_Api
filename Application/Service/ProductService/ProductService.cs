using JWT_NET_5.Application.IReposatories;
using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Common.Model;
using JWT_NET_5.Core.Domain.ProductDomain;
using System;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.ProductService
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductService(IUnitOfWork unitOfWork )
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<ProductDto> CreateProduct(ProductCreateDto ProductCreateDto)
		{
			var product = Product.Create(
				Guid.NewGuid(),
					ProductCreateDto.ProductName
					, ProductCreateDto.Amount
					, ProductCreateDto.Cost
					, ProductCreateDto.UserId);
			var res= await _unitOfWork.ProductRepository.AddAsync(product);
			return new ProductDto();
			
		}

		public  Task<bool> DeleteProduct(Guid id)
		{
			AssertionConcern
				.AssertionAgainstNotNull(id,
				"Error Deleting Product,Invalid Product Id");
			var product =  _unitOfWork.ProductRepository.Find(e=>e.Id==id);
			AssertionConcern.AssertionAgainstNotNull(product,$"No Product With Id {id}");
			 _unitOfWork.ProductRepository.Delete(product);
			return true;
		}

		public Task<Product> GetProductById(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetProductByName(string name)
		{
			throw new NotImplementedException();
		}

		public Task<Product> UpdateProduct(ProductUpdateDto ProductDto)
		{
			throw new NotImplementedException();
		}
	}
}
