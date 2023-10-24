

using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
	public interface ILocationsService
	{
		Task<City?> GetAutocomplete(string locationName);
		Task<City[]?> GetLocations(string locationName);
	}
}