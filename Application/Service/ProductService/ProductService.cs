using AutoMapper;
using JWT_NET_5.Application.IReposatories;
using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Common.Model;
using JWT_NET_5.Core.Domain.ProductDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_NET_5.Application.Service.ProductService
{

	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
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
			_unitOfWork.Complete();
			return _mapper.Map <ProductDto>(res);
		}

		public  async Task<bool> DeleteProduct(Guid id)
		{
			AssertionConcern
				.AssertionAgainstNotNull(id,
				"Error Deleting Product,Invalid Product Id");
			var product =  _unitOfWork.ProductRepository.Find(e=>e.Id==id);
			AssertionConcern.AssertionAgainstNotNull(product,$"No Product With Id {id}");
			 _unitOfWork.ProductRepository.Delete(product);
			_unitOfWork.Complete();
			return await Task.FromResult(true);
		}

		public async Task<ProductDto> GetProductById(Guid id)
		{
			AssertionConcern
				.AssertionAgainstNotNull(id,"Invalid Product Id");
			var product = await _unitOfWork.ProductRepository.FindAsync(e=>e.Id==id);
			return product is null ? null : _mapper.Map<ProductDto>(product);
		}

		public async Task<ProductDto> GetProductByName(string name)
		{
			AssertionConcern
				.AssertionAgainstNotNullOrEmplty(name, "Invalid Product Name");
			var product = await _unitOfWork.ProductRepository.FindAsync(e => e.ProductName == name);
			return product is null ? null : _mapper.Map<ProductDto>(product);
		}

		public async Task<List<ProductDto>> GetProducts()
		{
			var productList = await _unitOfWork.ProductRepository.GetAllAsync();
			if (productList is not null || productList.ToList().Count > 0)
				return _mapper.Map<List<ProductDto>>(productList.ToList());
			return null;
		}

		public async Task<ProductDto> UpdateProduct(Guid id ,ProductUpdateDto ProductDto)
		{
			AssertionConcern
				.AssertionAgainstNotNull(ProductDto, "Invalid Product ");
			var oldProduct=await _unitOfWork.ProductRepository
				.FindAsync(e => e.Id == id);
			AssertionConcern
				.AssertionAgainstNotNull(oldProduct, $"Product With Id {id} Not Found");
			var res = _unitOfWork.ProductRepository.Update(_mapper.Map<Product>(ProductDto));
			_unitOfWork.Complete();
			return res is null?null: _mapper.Map<ProductDto>(res);
		}
	}
}
