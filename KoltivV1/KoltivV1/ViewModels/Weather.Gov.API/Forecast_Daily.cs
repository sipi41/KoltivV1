using Microsoft.AspNetCore.Rewrite;
using System.Text.Json.Serialization;

namespace KoltivV1.ViewModels.Weather.Gov.API
{
   
    public class Forecast_Daily 
    {
        [JsonPropertyName("generatedAt")]
        public DateTime GeneratedAt { get; set; }

        [JsonPropertyName("updateTime")]
        public DateTime UpdateTime { get; set; }

        [JsonPropertyName("validTimes")]
        public string ValidTimes { get; set; }

        [JsonPropertyName("periods")]
        public List<Forecast_Period> Periods { get; set; }
    }
}
