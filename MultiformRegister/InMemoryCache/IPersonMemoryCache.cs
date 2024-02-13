using Microsoft.Extensions.Caching.Distributed;
using MultiformRegister.ViewModel;

namespace MultiformRegister.InMemoryCache
{
	public interface IPersonMemoryCache : IMemoryCache<Person>
	{
	}

	public class PersonMemoryCache : DistributedMemoryCache<Person>, IPersonMemoryCache
	{
		public PersonMemoryCache(IDistributedCache cache) : base(cache)
		{
		}
	}
}
