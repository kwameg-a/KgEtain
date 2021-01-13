using KgEtain.Models;
using System.Threading.Tasks;

namespace KgEtain.Services
{
    public interface IBelfastWeatherService
    {
        Task<int> GetWhereOnEarthIDAsync();
        Task<ApiResponse> GetApiResponse(int whereOnEarthID);
    }
}