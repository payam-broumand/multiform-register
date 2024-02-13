using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MultiformRegister.InMemoryCache
{
    public interface IMemoryCache<T> where T : class
    {
        T? Get(string key);

        void Set(string key, T value);  
    }

    public class DistributedMemoryCache<T> : IMemoryCache<T> where T : class
    {
        private readonly IDistributedCache _cache; 

        public DistributedMemoryCache(IDistributedCache cache)
        {
            _cache = cache;
        }
         

        public T? Get(string key)
        {
            var dataModel = _cache.GetString(key);
            return dataModel is not null
                ? JsonConvert.DeserializeObject<T>(dataModel)
                : null;
        }

        public void Set(string key, T value)
        {
            var serializedData = JsonConvert.SerializeObject(value);
            _cache.SetString(key, serializedData);
        }
    } 

}
