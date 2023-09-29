using PieShopHRM.Shared.Domain;
using System.Text.Json;

namespace PieShopHRM.Services
{
    public class CountryDataService : ICountryDataService
    {
        private HttpClient _httpClient;
        public CountryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
                (await _httpClient.GetStreamAsync($"api/country"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Country> GetCountryById(int countryId)
        {
            return await JsonSerializer.DeserializeAsync<Country>
               (await _httpClient.GetStreamAsync($"api/country/{countryId}"),
               new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
