using JWT_NET_5.Application.Service.ProductService;
using JWT_NET_5.Application.Service.ProductService.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWT_NET_5.Controllers
{
	[Authorize]
	[Route("api/Products")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet("Name")]
		[Authorize(Roles ="Admin")]
		public async Task<ProductDto> GetProduct(string name)
		{
			return await _productService.GetProductByName(name);
		}
	}
}
