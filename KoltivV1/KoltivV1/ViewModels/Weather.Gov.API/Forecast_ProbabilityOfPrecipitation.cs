using System.Text.Json.Serialization;

namespace KoltivV1.ViewModels.Weather.Gov.API
{
    public class Forecast_ProbabilityOfPrecipitation 
    {
        [JsonPropertyName("unitCode")]
        public string UnitCode { get; set; }

        [JsonPropertyName("value")]
        public float Value { get; set; }
    }
}
