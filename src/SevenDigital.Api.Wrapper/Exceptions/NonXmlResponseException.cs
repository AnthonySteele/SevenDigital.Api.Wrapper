using System;
using System.Net;
using System.Runtime.Serialization;

namespace SevenDigital.Api.Wrapper.Exceptions
{
	[Serializable]
	public class NonXmlResponseException : ApiException
	{
		public const string DEFAULT_ERROR_MESSAGE = "Error deserializing xml response";
		public string ResponseBody { get; set; }
		public HttpStatusCode StatusCode { get; set; }

		public NonXmlResponseException()
			: base(DEFAULT_ERROR_MESSAGE)
		{
		}

		public NonXmlResponseException(string message)
			: base(message)
		{
		}

		public NonXmlResponseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected NonXmlResponseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}