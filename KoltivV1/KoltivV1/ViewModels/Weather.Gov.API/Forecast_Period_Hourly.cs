namespace KoltivV1.ViewModels.Weather.Gov.API
{
    public class Forecast_Period_Hourly : Forecast_Period
    {
        public Forecast_DewPoint dewpoint { get; set; }
        public Forecast_RelativeHumidity relativeHumidity { get; set; }
    }
}
