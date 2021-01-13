using KgEtain.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KgEtain.Services
{
    public class BelfastWeatherService : IBelfastWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly MetaWeatherApiConfig _metaWeatherApiConfig;

        public BelfastWeatherService(
            HttpClient httpClient,
            IOptionsMonitor<MetaWeatherApiConfig> optionsMonitor)
        {
            _httpClient = httpClient;
            _metaWeatherApiConfig = optionsMonitor.CurrentValue;
        }

        public async Task<int> GetWhereOnEarthIDAsync()
        {
            try
            {
                var jsonString = await _httpClient.GetStringAsync(_metaWeatherApiConfig.BelfastLocationSearchUrl);
                var apiResponse = JsonConvert.DeserializeObject<LocationSearch[]>(jsonString);
                return apiResponse.Select(s => s.WhereOnEarthID).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;               
            }
        }



        public async Task<ApiResponse> GetApiResponse(int whereOnEarthID)
        {
            try
            {
                var jsonString = await _httpClient.GetStringAsync($"{_metaWeatherApiConfig.BaseLocationUrl}{whereOnEarthID}");
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                return apiResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
