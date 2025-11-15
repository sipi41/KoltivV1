using KoltivV1.ViewModels.Weather.Gov.API;

namespace KoltivV1.Application
{
    public interface IWeatherRepository
    {
        Task<IWeatherPoint?> GetPointInformation(float lat, float lng);

        Task<Forecast_Hourly?> Get_Hourly_Forecast(string ForecastEndpoint);

        Task<Forecast_Daily?> Get_Daily_Forecast(string ForecastEndpoint);



    }
}