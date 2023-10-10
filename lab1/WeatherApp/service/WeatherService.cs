using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    internal class WeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language={2}";
        private const string daily_forecast_endpoint = "forecasts/v1/daily/{0}day/{1}?apikey={2}&language={3}&metric={4}";
        private const string api_key = "ZFYvdPJxJ03WoYUMfvQLgIL9JOABTWgC";
        private const string language = "pl";

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<Weather> GetHistoricalCurrentConditions(string cityKey, int hours)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<Weather> GetDailyForecast(string cityKey, int days)
        {
            string uri = base_url + "/" + string.Format(daily_forecast_endpoint, days, cityKey, api_key,language, true);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Weather>(json);
            }
        }
    }
}
