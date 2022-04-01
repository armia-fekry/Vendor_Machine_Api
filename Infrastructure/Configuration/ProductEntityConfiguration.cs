using JWT_NET_5.Core.Domain.ProductDomain;
using JWT_NET_5.Core.Domain.UserDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_NET_5.Infrastructure.Configuration
{
	public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(e=>e.Id).IsRequired();
			builder.Property(e=>e.Cost).IsRequired();
			builder.Property(e=>e.Amount).IsRequired();
			builder.Property(e=>e.ProductName).IsRequired();
			builder.Property(e=>e.UserId).IsRequired();
			builder.HasOne(u=>u.User).WithMany(p=>p.Products).HasForeignKey(p=>p.UserId);

		}
	}
}
