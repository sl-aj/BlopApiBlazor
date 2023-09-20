using Newtonsoft.Json;

namespace ApiBlazor.Data
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;
        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                WeatherForecast[] forecasts = JsonConvert.DeserializeObject<WeatherForecast[]>(json);
                return forecasts;
            }

            return null;
        }
    }
}