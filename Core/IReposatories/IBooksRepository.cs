using System.Collections.Generic;

namespace JWT_NET_5.Core.IReposatories
{
	public interface IBooksRepository : IBaseRepository<string>
    {
        IEnumerable<string> SpecialMethod();
    }
}