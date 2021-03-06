using JWT_NET_5.Application.IReposatories;
using JWT_NET_5.Infrastructure.Data;

namespace JWT_NET_5.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
    {
        private readonly JWTDbContext _context;



        public UnitOfWork(JWTDbContext context)
        {
            _context = context;

            ProductRepository = new ProductRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        public IProductRepository ProductRepository {get;protected set;}
        public IUserRepository UserRepository {get;private set;}

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
