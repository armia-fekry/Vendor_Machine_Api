using JWT_NET_5.EntityFrameork.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT_NET_5.Infrastructure.Data
{
	public class JWTDbContext:IdentityDbContext<ApplicationUser>
	{
		public JWTDbContext(DbContextOptions<JWTDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
