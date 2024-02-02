using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class WeatherViewModel
    {
        public string info { get; set; }

        public WeatherViewModel(Weather weather)
        {
            info = weather.ToString();
        }

        public WeatherViewModel(HistoricalForecast forecast)
        {
            info = forecast.ToString();
        }

        public WeatherViewModel(HourlyForecasts hourlyForecast)
        {
            info = hourlyForecast.ToString();
        }

        public WeatherViewModel(DailyForecasts dailyForecasts)
        {
            info = dailyForecasts.ToString();
        }

    }
}