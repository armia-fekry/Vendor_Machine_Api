using JWT_NET_5.Core.Domain.UserDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JWT_NET_5.Infrastructure.Configuration
{
	public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");
			builder.Property(u => u.Role).IsRequired();
			builder.Property(u => u.UserName).IsRequired();
			builder.Property(u => u.Password).IsRequired();
		}
	}
}
