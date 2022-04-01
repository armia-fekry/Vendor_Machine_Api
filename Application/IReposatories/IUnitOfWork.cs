using System;

namespace JWT_NET_5.Application.IReposatories
{
	public interface IUnitOfWork : IDisposable
    {
		public IProductRepository ProductRepository { get; }
		public IUserRepository UserRepository { get; }
		int Complete();
    }
}