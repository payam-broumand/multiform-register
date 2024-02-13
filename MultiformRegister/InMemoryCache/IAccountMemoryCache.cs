using Microsoft.Extensions.Caching.Distributed;
using MultiformRegister.ViewModel;

namespace MultiformRegister.InMemoryCache
{
	public interface IAccountMemoryCache : IMemoryCache<Account> { }

	public class AccountMemoryCache : DistributedMemoryCache<Account>, IAccountMemoryCache
	{
		public AccountMemoryCache(IDistributedCache cache) : base(cache)
		{
		}
	}
}
