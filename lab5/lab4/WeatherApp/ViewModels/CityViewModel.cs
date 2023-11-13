using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class CityViewModel
    {
        public string LocalizedName { get; set; }
        public string Key { get; set; }
        public string info {  get; set; }

        public CityViewModel(City city)
        {
            LocalizedName = city.LocalizedName;
            Key = city.Key;
            info = city.ToString();
        }
    }
}
