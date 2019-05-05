using HttpPerformance.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpPerformance.Services
{
    public class NonReuseHttpClientService
    {
        private static NonReuseHttpClientService _instance;

        public static NonReuseHttpClientService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NonReuseHttpClientService();
                return _instance;
            }
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await httpClient.GetAsync(AppSettings.ServiceEndpoint);

            string serialized = await response.Content.ReadAsStringAsync();
            IEnumerable<Photo> result = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Photo>>(serialized));

            return result;
        }
    }
}