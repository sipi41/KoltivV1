using System.Text.Json.Serialization;

namespace KoltivV1.ViewModels.Weather.Gov.API
{
    public class Forecast_DewPoint 
    {
        [JsonPropertyName("unitCode")]
        public string UnitCode { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public float Value { get; set; }
    }
}
