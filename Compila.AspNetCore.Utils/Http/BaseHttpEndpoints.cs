namespace Compila.AspNetCore.Utils.Http
{
    public interface IEndpointData
    {
        string BaseUrl { get; set; }
    }

    public class EndpointSite : IEndpointData
    {
        public string BaseUrl { get; set; }

        public EndpointSite(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }

    public class ProtectedEndpointSite : IEndpointData
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }

        public ProtectedEndpointSite(string baseUrl, string apiKey)
        {
            BaseUrl = baseUrl;
            ApiKey = apiKey;
        }
    }
}
