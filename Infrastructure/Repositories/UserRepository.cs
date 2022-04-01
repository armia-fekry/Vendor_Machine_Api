using JWT_NET_5.Application.IReposatories;
using JWT_NET_5.Core.Domain.UserDomain;
using JWT_NET_5.Infrastructure.Data;

namespace JWT_NET_5.Infrastructure.Repositories
{
	public class UserRepository:BaseRepository<User>,IUserRepository
    {
		public UserRepository(JWTDbContext context):base(context)
		{

		}
    }
}
