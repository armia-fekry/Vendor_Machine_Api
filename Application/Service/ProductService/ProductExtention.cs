using JWT_NET_5.Application.Service.ProductService.Dto;
using JWT_NET_5.Core.Domain.ProductDomain;

namespace JWT_NET_5.Core.Application.ProductDomain
{
	public static class ProductExtention
    {
        public static Product UpdateWith(this Product oldProduct, ProductUpdateDto newProduct)
        {
            oldProduct.ProductName = newProduct.ProductName;
            oldProduct.Cost = newProduct.Cost;
            oldProduct.Amount = newProduct.Amount;
            oldProduct.UserId = newProduct.UserId;
            return oldProduct;
        }
    }
}
