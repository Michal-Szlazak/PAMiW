using Newtonsoft.Json;
using WeatherApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.error;

namespace WeatherApp.service.WeatherServices
{
    internal class LocationService : ILocationsService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string city_endpoint = "locations/v1/cities/search?apikey={0}&q={1}&language{2}";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string api_key = "hx3nS6VG69ijuDHcnF3E5CHuhx6Mdum0";
        private const string language = "en";

        public async Task<City?> GetAutocomplete(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    City[]? cities = JsonConvert.DeserializeObject<City[]>(json);
                    return cities != null ? cities[0] : null;
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

        public async Task<City[]?> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(city_endpoint, api_key, locationName, language);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<City[]>(json);
                }
            }
            catch (JsonReaderException)
            {
                ErrorMessege.showMessege();
                return null;
            }
            catch (JsonSerializationException)
            {
                ErrorMessege.showMessege(); ;
                return null;
            }
        }
    }
}
