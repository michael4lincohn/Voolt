using Newtonsoft.Json;
using System.Text;
using Voolt.Test.Blazor.Dtos;
using Voolt.Test.Blazor.Services.Extensions;

namespace Voolt.Test.Blazor
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        public static string Url { get; set; }

        public ApiService(
            IConfiguration configuration,
            HttpClient httpClient)
        {
            _httpClient = httpClient;
            Url = configuration["BackendApiUri"];
        }

        public async Task<ApiResponse<IEnumerable<AdDto>>> GetAllAsync()
        {
            return await GetResponse<IEnumerable<AdDto>>($"Ad");
        }

        public async Task<ApiResponse<bool>> CreateOrUpdateAsync(AdDto request)
        {
            return await PostResponse<AdDto, bool>(request, $"Ad");
        }

        #region Private

        public static string UriCombine(string uri1, string uri2)
        {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}/{1}", uri1, uri2);
        }

        private async Task<ApiResponse<T>> GetResponse<T>(string endpoint)
        {
            try
            {
                var uri = UriCombine(Url, endpoint);
                var responseMessage = await _httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode && responseMessage.Content != null && responseMessage.Content.TryReadFromJsonAsync<ApiResponse<T>>(out var result))
                    return result;

                return new ApiResponse<T> { StatusCode = (int)responseMessage.StatusCode, Success = false };
            }
            catch (Exception e)
            {
                return new ApiResponse<T>
                {
                    StatusCode = 500,
                    Success = false
                };
            }
        }

        private async Task<ApiResponse<U>> PostResponse<T, U>(T request, string endpoint)
        {
            try
            {
                var uri = UriCombine(Url, endpoint);
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var responseMessage = await _httpClient.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode && responseMessage.Content != null && responseMessage.Content.TryReadFromJsonAsync<ApiResponse<U>>(out var result))
                    return result;

                return new ApiResponse<U> { StatusCode = (int)responseMessage.StatusCode, Success = false };
            }
            catch (Exception e)
            {
                return new ApiResponse<U>
                {
                    StatusCode = 500,
                    Success = false
                };
            }
        }

        #endregion
    }
}