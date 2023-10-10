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
    internal class LocationService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string api_key = "ZFYvdPJxJ03WoYUMfvQLgIL9JOABTWgC";
        private const string language = "pl";

        // public AccuWeatherService()
        // {
        //     var builder = new ConfigurationBuilder()
        //         .AddUserSecrets<App>()
        //         .SetBasePath(Directory.GetCurrentDirectory())
        //         .AddJsonFile("appsetings.json"); 

        //     var configuration = builder.Build();
        //     api_key = configuration["api_key"];
        //     language = configuration["default_language"];
        // }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
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
