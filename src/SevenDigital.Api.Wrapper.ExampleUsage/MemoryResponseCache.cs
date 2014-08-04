using System;
using System.Runtime.Caching;
using SevenDigital.Api.Wrapper.Requests;
using SevenDigital.Api.Wrapper.Responses;

namespace SevenDigital.Api.Wrapper.ExampleUsage
{
	public class MemoryResponseCache : IResponseCache
	{
		private readonly MemoryCache _memoryCache;

		public MemoryResponseCache(MemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public void Set(RequestData key, object value)
		{
			var memoryCacheKey = MakeCacheKey(key);
			_memoryCache.Set(memoryCacheKey, value, DefaultExpiration());
		}

		public bool TryGet<T>(RequestData key, out T value)
		{
			var cacheKey = MakeCacheKey(key);
			var cacheValue = _memoryCache.Get(cacheKey);

			if (cacheValue is T)
			{
				value = (T)cacheValue;
				return true;
			}

			value = default(T);
			return false;
		}

		private string MakeCacheKey(RequestData key)
		{
			var paramValues = string.Join("_", key.Parameters);
			return "7digital_" + key.HttpMethod + "_" + key.Endpoint + "_" + paramValues;
		}

		private DateTimeOffset DefaultExpiration()
		{
			return DateTimeOffset.Now.AddMinutes(10);
		}
	}
}
