using NativeStats.Models;

namespace NativeStats.Services
{
    public class FootballDataService
    {
        private readonly HttpClient _httpClient;

        public FootballDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.football-data.org/v4/");
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "217d35d3aa17466db72738526496eb9a");
        }

        public async Task<List<Match>> GetMatchesAsync(string competitionCode, string status)
        {
            var response = await _httpClient.GetAsync($"competitions/{competitionCode}/matches?status={status?.ToUpper()}");

            var apiResponse = await response.Content.ReadFromJsonAsync<FootballApiResponse>();

            return apiResponse?.Matches;
        }
    }
}
