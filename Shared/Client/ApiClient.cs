using Newtonsoft.Json;
using System.Text;

namespace Framework.Shared.Client
{
    public class ApiClient : IApiClient
    {
        public HttpClient httpClient { get; private set; }

        public ApiClient(string baseUrl)
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());

            string? jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }
        

        public async Task PostAsync<T>(string url, T body)
        {
            using StringContent jsonContent = new(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PostAsync(
                url,
                jsonContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());
        }

        public async Task<R?> PutAsync<T, R>(string url, T body)
        {
            using StringContent jsonContent = new(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PutAsync(
                url,
                jsonContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());

            string? jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<R>(jsonResponse);
        }

        public async Task<R?> PatchAsync<T, R>(string url, T body)
        {
            using StringContent jsonContent = new(
                JsonConvert.SerializeObject(body),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await httpClient.PatchAsync(
                url,
                jsonContent);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());

            string? jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<R>(jsonResponse);
        }

        public async Task DeleteAsync(string url)
        {
            using HttpResponseMessage response = await httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.StatusCode.ToString());

        }
    }
}
