using Newtonsoft.Json;
using WeatherApp.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
    internal class LocationService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string city_endpoint = "locations/v1/cities/search?apikey={0}&q={1}&language{2}";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string api_key = "Y7GCz7CFGzrF7T8YlYWEVdlG53o2HQZz";
        private const string language = "en";

        public async Task<City> GetAutocomplete(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities[0];
            }
        }

        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(city_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }
    }
}
