

using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{

    public interface IWeatherService
    {
        Task<Weather[]> GetCurrentConditions(string cityKey);
        Task<List<HistoricalForecast>?> GetHistoricalCurrentConditions6h(string cityKey);
        Task<List<HistoricalForecast>?> GetHistoricalCurrentConditions24h(string cityKey);
        Task<Weather?> GetDailyForecast(string cityKey, int days);
        Task<HourlyForecasts[]> GetHourlyForecast(string cityKey, int hours);
    }
}