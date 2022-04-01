using JWT_NET_5.Application.Service.ProductService;
using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JWT_NET_5.Controllers
{
	[Authorize]
	[Route("api")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}
		// GET: api/products
		[HttpGet("Products")]
		public async Task<List<ProductDto>> Get()
		{
			return await _productService.GetProducts();
		}

		// GET api/products/5
		[HttpGet("Product/{id}")]
		public async Task<ProductDto> Get(Guid id)
		{
			return await _productService.GetProductById(id);
		}

		// POST api/products
		[HttpPost("Product")]
		[Authorize(Roles = "Seller")]
		public async Task<ProductDto> Post([FromBody] ProductCreateDto productCreateDto)
		{
			return await _productService.CreateProduct(productCreateDto);
		}

		// PUT api/products/5
		[Authorize(Roles = "Seller")]
		[HttpPut("Product/{id}")]
		public async Task<ActionResult<ProductDto>> Put(Guid id, [FromBody] ProductUpdateDto updateDto)
		{
			if (!ModelState.IsValid)
				return BadRequest("Comlete requierd Fields ");
			AssertionConcern.AssertionAgainstNotNull(id, "Invalid Product Id");
			return Ok(await _productService.UpdateProduct(id,updateDto));
		}

		// DELETE api/products/5
		[Authorize(Roles = "Seller")]
		[HttpDelete("Product/{id}")]
		public async Task<ActionResult<bool>> Delete(Guid id)
		{
			if (id == default(Guid)) return BadRequest("Invalid ID ");
			return Ok(await _productService.DeleteProduct(id));
		}
	}
}

