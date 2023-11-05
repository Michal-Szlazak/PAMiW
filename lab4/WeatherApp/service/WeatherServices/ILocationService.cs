

using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.service.WeatherServices
{
    public interface ILocationsService
    {
        Task<City?> GetAutocomplete(string locationName);
        Task<City[]?> GetLocations(string locationName);
    }
}