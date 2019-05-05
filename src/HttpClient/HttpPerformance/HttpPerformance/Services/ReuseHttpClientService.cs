using HttpPerformance.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpPerformance.Services
{
    public class ReuseHttpClientService
    {
        private static HttpClient httpClient = new HttpClient();

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
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync(AppSettings.ServiceEndpoint);

            string serialized = await response.Content.ReadAsStringAsync();
            IEnumerable<Photo> result = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Photo>>(serialized));

            return result;
        }
    }
}
