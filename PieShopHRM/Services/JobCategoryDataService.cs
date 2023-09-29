using PieShopHRM.Shared.Domain;
using System.Net.Http;
using System.Text.Json;

namespace PieShopHRM.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private HttpClient _httpClient;
        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
              (await _httpClient.GetStreamAsync($"api/jobCategory"),
              new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>
             (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"),
             new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
