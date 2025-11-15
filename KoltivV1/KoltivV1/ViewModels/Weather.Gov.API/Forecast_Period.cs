using System.Text.Json.Serialization;

namespace KoltivV1.ViewModels.Weather.Gov.API
{
    public class Forecast_Period 
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("isDaytime")]
        public bool IsDaytime { get; set; }

        [JsonPropertyName("temperature")]
        public int Temperature { get; set; }

        [JsonPropertyName("temperatureUnit")]
        public string TemperatureUnit { get; set; }

        [JsonPropertyName("temperatureTrend")]
        public string TemperatureTrend { get; set; }

        [JsonPropertyName("probabilityOfPrecipitation")]
        public Forecast_ProbabilityOfPrecipitation ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName("windSpeed")]
        public string WindSpeed { get; set; }

        [JsonPropertyName("windDirection")]
        public string WindDirection { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("shortForecast")]
        public string ShortForecast { get; set; }

        [JsonPropertyName("detailedForecast")]
        public string DetailedForecast { get; set; }
    }
}
