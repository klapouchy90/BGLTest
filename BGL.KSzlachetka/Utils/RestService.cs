using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BGL.KSzlachetka.Utils
{
    public abstract class RestService
    {
        protected Uri BaseUrl { get; }

        public RestService(string baseUrl) : this(new Uri(baseUrl))
        {
        }

        public RestService(Uri baseUrl) : this()
        {
            BaseUrl = baseUrl;
        }

        public RestService()
        {
        }

        protected async Task<T> GetObjectFromJsonRequest<T>(string requestUri)
            where T : class
        {
            if (requestUri == null)
            {
                throw new ArgumentNullException(nameof(requestUri));
            }
            using (var client = new HttpClient() { BaseAddress = BaseUrl })
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(requestUri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() } });
                }
                else
                {
                    throw new HttpException(response.ReasonPhrase, (int)response.StatusCode);
                }
            }
        }
    }
}