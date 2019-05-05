using HttpPerformance.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpPerformance.Services
{
    public class ReuseStreamHttpClientService
    {
        private JsonSerializer _serializer = new JsonSerializer();
        private static HttpClient _httpClient = new HttpClient();

        private static ReuseHttpClientService _instance;

        public static ReuseHttpClientService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ReuseHttpClientService();
                return _instance;
            }
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            HttpResponseMessage response = await _httpClient.GetAsync(AppSettings.ServiceEndpoint);

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<IEnumerable<Photo>>(json);
            }
        }
    }
}