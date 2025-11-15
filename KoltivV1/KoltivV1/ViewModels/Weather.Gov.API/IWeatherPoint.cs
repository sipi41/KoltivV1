namespace KoltivV1.ViewModels.Weather.Gov.API
{
    public interface IWeatherPoint
    {
        string Forecast { get; set; }
        string ForecastGridData { get; set; }
        string ForecastHourly { get; set; }
        string GridId { get; set; }
        int GridX { get; set; }
        int GridY { get; set; }
        RelativeLocation RelativeLocation { get; set; }
    }
}