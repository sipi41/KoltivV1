namespace KoltivV1.ViewModels.Weather.Gov.API
{
    public class WeatherPoint : IWeatherPoint
    {

        public string GridId { get; set; } = string.Empty;
        public int GridX { get; set; }
        public int GridY { get; set; }
        public string Forecast { get; set; } = string.Empty;
        public string ForecastHourly { get; set; } = string.Empty;
        public string ForecastGridData { get; set; } = string.Empty;
        public RelativeLocation RelativeLocation { get; set; } = new();

    }

    public class RelativeLocation
    {
        public RelativeLocationProperties Properties { get; set; } = new();
    }

    public class RelativeLocationProperties
    {
        public string? City { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;
    }

}
