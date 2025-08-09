using System.Net.Http;

namespace FemmeTranslate.Utilities.Http
{
    public class ApiClientFactory
    {
        private readonly IHttpClientFactory _factory;
        public ApiClientFactory(IHttpClientFactory factory) => _factory = factory;
        public HttpClient Create(string name) => _factory.CreateClient(name);
    }
}
