using JWT_NET_5.Application.IReposatories;
using JWT_NET_5.Core.Domain.ProductDomain;
using JWT_NET_5.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NET_5.Infrastructure.Repositories
{
	public class ProductRepository :BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(JWTDbContext context):base(context)
		{
		}
		

	}
}
