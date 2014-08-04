using System.Runtime.Caching;

namespace SevenDigital.Api.Wrapper.ExampleUsage
{
	public class ExampleApi : IApi
	{
		private readonly IApi _standardApi;
		private readonly MemoryResponseCache _cache;

		public ExampleApi()
		{
			var apiUri = new ApiUri();
			var oauthCredentials = new AppSettingsCredentials();
			_standardApi = new ApiFactory(apiUri, oauthCredentials);

			_cache = new MemoryResponseCache(MemoryCache.Default);
		}

		public IFluentApi<T> Create<T>() where T : class, new()
		{
			return _standardApi.Create<T>()
				.UsingCache(_cache);
		}
	}
}
