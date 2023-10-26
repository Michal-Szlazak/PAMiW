using Newtonsoft.Json;
using WeatherApp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.error;

namespace WeatherApp.service.WeatherServices
{
    internal class WeatherService : IWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language={2}";
        private const string historical_current_conditions_endpoint_6h = "currentconditions/v1/{0}/historical?apikey={1}&language={2}&details={3}";
        private const string historical_current_conditions_endpoint_24h = "currentconditions/v1/{0}/historical/24?apikey={1}&language={2}&details={3}";
        private const string daily_forecast_endpoint = "forecasts/v1/daily/{0}day/{1}?apikey={2}&language={3}&metric={4}&details={5}";
        private const string hourly_forecast_endpoint = "forecasts/v1/hourly/{0}hour/{1}?apikey={2}&language={3}&metric={4}&details={5}";
        private const string api_key = "hx3nS6VG69ijuDHcnF3E5CHuhx6Mdum0";
        private const string language = "en";

        public async Task<Weather[]> GetCurrentConditions(string cityKey)
        {
            try
            {
                string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Weather[]>(json);
                }
            }
            catch (JsonReaderException)
            {
                ErrorMessege.showMessege();
                return null;
            }
            catch (JsonSerializationException)
            {
                ErrorMessege.showMessege();
                return null;
            }

        }

        public async Task<List<HistoricalForecast>?> GetHistoricalCurrentConditions6h(string cityKey)
        {
            try
            {
                string uri = base_url + "/" + string.Format(historical_current_conditions_endpoint_6h, cityKey, api_key, language, true);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<HistoricalForecast>>(json);
                }
            }
            catch (JsonReaderException)
            {
                ErrorMessege.showMessege();
                return null;
            }
            catch (JsonSerializationException)
            {
                ErrorMessege.showMessege();
                return null;
            }
        }

        public async Task<List<HistoricalForecast>?> GetHistoricalCurrentConditions24h(string cityKey)
        {
            try
            {
                string uri = base_url + "/" + string.Format(historical_current_conditions_endpoint_24h, cityKey, api_key, language, true);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<HistoricalForecast>>(json);
                }
            }
            catch (JsonReaderException)
            {
                ErrorMessege.showMessege();
                return null;
            }
            catch (JsonSerializationException)
            {
                ErrorMessege.showMessege();
                return null;
            }
        }

        public async Task<Weather?> GetDailyForecast(string cityKey, int days)
        {
            try
            {
                string uri = base_url + "/" + string.Format(daily_forecast_endpoint, days, cityKey, api_key, language, true, true);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Weather>(json);
                }
            }
            catch (JsonReaderException)
            {
                ErrorMessege.showMessege();
                return null;
            }
            catch (JsonSerializationException)
            {
                ErrorMessege.showMessege();
                return null;
            }
        }

        public async Task<HourlyForecasts[]?> GetHourlyForecast(string cityKey, int hours)
        {
            try
            {
                string uri = base_url + "/" + string.Format(hourly_forecast_endpoint, hours, cityKey, api_key, language, true, true);
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<HourlyForecasts[]>(json);
                }
            }
            catch (JsonReaderException)
            {
                ErrorMessege.showMessege();
                return null;
            }
            catch (JsonSerializationException)
            {
                ErrorMessege.showMessege();
                return null;
            }
        }
    }
}
