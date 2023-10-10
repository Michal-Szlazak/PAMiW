using Newtonsoft.Json;
using WeatherApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    internal class WeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language={2}";
        private const string historical_current_conditions_endpoint_6h = "currentconditions/v1/{0}/historical?apikey={1}&language={2}&details={3}";
        private const string historical_current_conditions_endpoint_24h = "currentconditions/v1/{0}/historical/24?apikey={1}&language={2}&details={3}";
        private const string daily_forecast_endpoint = "forecasts/v1/daily/{0}day/{1}?apikey={2}&language={3}&metric={4}&details={5}";
        private const string hourly_forecast_endpoint = "forecasts/v1/hourly/{0}hour/{1}?apikey={2}&language={3}&metric={4}&details={5}";
        private const string api_key = "Y7GCz7CFGzrF7T8YlYWEVdlG53o2HQZz";
        private const string language = "en";

        public async Task<List<Weather>> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                List<Weather> weathers= JsonConvert.DeserializeObject<List<Weather>>(json);
                return weathers;
            }
        }

        public async Task<List<HistoricalForecast>> GetHistoricalCurrentConditions6h(string cityKey)
        {
            string uri = base_url + "/" + string.Format(historical_current_conditions_endpoint_6h, cityKey, api_key,language, true);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<HistoricalForecast>>(json);
            }
        }

        public async Task<List<HistoricalForecast>> GetHistoricalCurrentConditions24h(string cityKey)
        {
            string uri = base_url + "/" + string.Format(historical_current_conditions_endpoint_24h, cityKey, api_key, language, true);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<HistoricalForecast>>(json);
            }
        }

        public async Task<Weather> GetDailyForecast(string cityKey, int days)
        {
            string uri = base_url + "/" + string.Format(daily_forecast_endpoint, days, cityKey, api_key,language, true, true);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Weather>(json);
            }
        }

        public async Task<List<HourlyForecasts>> GetHourlyForecast(string cityKey, int hours)
        {
            string uri = base_url + "/" + string.Format(hourly_forecast_endpoint, hours, cityKey, api_key, language, true, true);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<HourlyForecasts>>(json);
            }
        }
    }
}
