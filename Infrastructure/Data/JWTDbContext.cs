using JWT_NET_5.Core.Domain.ProductDomain;
using JWT_NET_5.Core.Domain.UserDomain;
using JWT_NET_5.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace JWT_NET_5.Infrastructure.Data
{
	public class JWTDbContext:IdentityDbContext<User,IdentityRole<Guid>,Guid>
	{
		public JWTDbContext(DbContextOptions<JWTDbContext> options) : base(options)
		{

		}
		public DbSet<Product> Products { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			new ProductEntityConfiguration().Configure(builder.Entity<Product>());
			new UserEntityTypeConfiguration().Configure(builder.Entity<User>());
			base.OnModelCreating(builder);

		}
	}
}
