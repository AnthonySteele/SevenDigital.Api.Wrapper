using System.Runtime.Caching;
using SevenDigital.Api.Wrapper.Http;
using SevenDigital.Api.Wrapper.Requests;
using SevenDigital.Api.Wrapper.Responses.Parsing;

namespace SevenDigital.Api.Wrapper.ExampleUsage
{
	public class ApiFactory : IApi
	{
		private readonly RequestBuilder _requestBuilder;
		private readonly MemoryResponseCache _cache;

		public ApiFactory()
		{
			var apiUri = new ApiUri();
			var oauthCredentials = new AppSettingsCredentials();
			_requestBuilder = new RequestBuilder(apiUri, oauthCredentials);

			_cache = new MemoryResponseCache(MemoryCache.Default);
		}

		public IFluentApi<T> Create<T>() where T : class, new()
		{
			var api = new FluentApi<T>(new HttpClientMediator(), _requestBuilder, new ResponseParser(new ApiResponseDetector()));
			api.UsingCache(_cache);
			return api;
		}
	}
}
