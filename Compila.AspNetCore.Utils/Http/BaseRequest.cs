using RestSharp;

namespace Compila.AspNetCore.Utils.Http
{
	public class BaseRequest
	{
		public RestRequest RestRequest { get; set; }

		public BaseRequest(RestRequest restRequest)
		{
			RestRequest = restRequest;
		}
	}
}
