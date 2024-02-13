using Microsoft.Extensions.Caching.Distributed;
using MultiformRegister.ViewModel;

namespace MultiformRegister.InMemoryCache
{
	public interface IEducationMemoryCache : IMemoryCache<Education>
	{
	}

	public class EducationMemoryCache : DistributedMemoryCache<Education>, IEducationMemoryCache
	{
		public EducationMemoryCache(IDistributedCache cache) : base(cache)
		{
		}
	} 
	
}
