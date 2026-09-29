namespace Framework.Shared.Client
{
    public interface IApiClient
    {
        Task<T?> GetAsync<T>(string url);

        Task PostAsync<T>(string url, T body);

        Task<R?> PutAsync<T, R>(string url, T body);

        Task<R?> PatchAsync<T, R>(string url, T body);

        Task DeleteAsync(string url);
    }
}
