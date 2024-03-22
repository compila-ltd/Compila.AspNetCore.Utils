using System;
using System.Threading.Tasks;

using RestSharp;

namespace Compila.AspNetCore.Utils.Http
{
	public abstract class BaseHttpApiClient
	{
		private readonly RestClient restClient;

		public BaseHttpApiClient(IEndpointData endpointData, bool ignoreSsl = false)
		{
			var options = new RestClientOptions
			{
				RemoteCertificateValidationCallback = default,
				BaseUrl = new Uri(endpointData.BaseUrl)
			};

			if (ignoreSsl)
				options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

			restClient = new RestClient(options);
		}

		protected async Task<RestResponse<T>> ExecuteAsync<T>(BaseRequest request) where T : new()
		{
			request = TransformHeaders(request);
			var response = await restClient.ExecuteAsync<T>(request.RestRequest);

			return response;
		}

		protected async Task<RestResponse> ExecuteAsync(BaseRequest request)
		{
			request = TransformHeaders(request);
			var response = await restClient.ExecuteAsync(request.RestRequest);

			return response;
		}

		protected virtual BaseRequest TransformHeaders(BaseRequest request)
		{
			return request;
		}
	}
}
