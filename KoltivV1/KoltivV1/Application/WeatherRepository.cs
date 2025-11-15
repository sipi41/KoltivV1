using KoltivV1.ViewModels.Weather.Gov.API;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace KoltivV1.Application
{
    public class WeatherRepository : IWeatherRepository
    {
        private IHttpClientFactory HttpClientFactory { get; set; }

        private JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public WeatherRepository(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }

        private async Task<string> GetJsonFromAPI(string Endpoint)
        {
            using HttpClient client = HttpClientFactory.CreateClient("WeatherAPI");

            if(Endpoint.Contains("http", StringComparison.CurrentCultureIgnoreCase)) Endpoint = Endpoint.Replace(client.BaseAddress.ToString(), "");

            client.DefaultRequestHeaders.Add("User-Agent", "(localhost, sipi.perez@gmail.com)");

            return await client.GetStringAsync(Endpoint);
        }
        public async Task<IWeatherPoint?> GetPointInformation(float lat, float lng)
        {
            string Endpoint = $"/points/{lat},{lng}";

            string APIResponse = await GetJsonFromAPI(Endpoint);

            JsonNode? originalNode = JsonNode.Parse(APIResponse);

            if (originalNode != null && originalNode["properties"] != null)
            {
                WeatherPoint? WeatherPoint = JsonSerializer.Deserialize<WeatherPoint>(originalNode["properties"], JsonSerializerOptions);

                return WeatherPoint;

            }
            else throw new Exception("Error parsing JSON response from Weather API.");

        }
        public async Task<Forecast_Hourly?> Get_Hourly_Forecast(string ForecastEndpoint)
        {
            string APIResponse = await GetJsonFromAPI(ForecastEndpoint);

            JsonNode? originalNode = JsonNode.Parse(APIResponse);

            if (originalNode != null && originalNode["properties"] != null)
            {
                Forecast_Hourly? forecastData = JsonSerializer.Deserialize<Forecast_Hourly>(originalNode["properties"], JsonSerializerOptions);

                return forecastData;

            }
            else throw new Exception("Error parsing JSON response from Weather Hourly API.");
        }

        public async Task<Forecast_Daily?> Get_Daily_Forecast(string ForecastEndpoint)
        {
            string APIResponse = await GetJsonFromAPI(ForecastEndpoint);

            JsonNode? originalNode = JsonNode.Parse(APIResponse);

            if (originalNode != null && originalNode["properties"] != null)
            {
                Forecast_Daily? forecastData = JsonSerializer.Deserialize<Forecast_Daily>(originalNode["properties"], JsonSerializerOptions);

                return forecastData;

            }
            else throw new Exception("Error parsing JSON response from Weather Daily API.");
        }
    }
}
