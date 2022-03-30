using JWT_NET_5.Core.IReposatories;
using System;

namespace JWT_NET_5.IReposatories
{
	public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<string> Authors { get; }
        IBooksRepository Books { get; }
        int Complete();
    }
}