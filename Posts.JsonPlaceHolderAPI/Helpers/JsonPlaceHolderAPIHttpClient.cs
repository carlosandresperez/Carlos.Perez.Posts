using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Posts.JsonPlaceHolderAPI.Helpers
{
    public class JsonPlaceHolderAPIHttpClient
    {
        private readonly HttpClient _client;

        public JsonPlaceHolderAPIHttpClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
    }
}
