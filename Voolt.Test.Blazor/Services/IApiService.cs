using Voolt.Test.Blazor.Dtos;

namespace Voolt.Test.Blazor
{
    public interface IApiService
    {
        Task<ApiResponse<IEnumerable<AdDto>>> GetAllAsync();
        Task<ApiResponse<bool>> CreateOrUpdateAsync(AdDto request);
    }
}