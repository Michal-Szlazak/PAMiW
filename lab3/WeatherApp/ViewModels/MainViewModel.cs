using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using WeatherApp.Models;
using WeatherApp.service.WeatherServices;
using WeatherApp.ViewModels;

namespace WeatherApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        
        private readonly IWeatherService _weatherService;
        private readonly ILocationsService _locationsService;
        private readonly IServiceProvider _serviceProvider;

        public ObservableCollection<CityViewModel> Cities { get; set; }
        public ObservableCollection<WeatherViewModel> Weathers { get; set; }

        private string _searchInput;

        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                if (_searchInput != value)
                {
                    _searchInput = value;
                    OnPropertyChanged(nameof(SearchInput));
                }
            }
        }

        public CityViewModel _selectedCity;

        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<WeatherViewModel> Conditions { get; set; }

        public MainViewModel(IWeatherService weatherService, ILocationsService locationService,
            IServiceProvider serviceProvider)
        {
            _weatherService = weatherService;
            _locationsService = locationService;
            _serviceProvider = serviceProvider;

            Weathers = new ObservableCollection<WeatherViewModel>();
            Conditions = new ObservableCollection<WeatherViewModel>();
            Cities = new ObservableCollection<CityViewModel>();
        }

        [RelayCommand]
        public async void Autocomplete(string locationName)
        {
            City? city = await _locationsService.GetAutocomplete(locationName);
            if(city != null)
            {
                SearchInput = city.LocalizedName;
            }
        }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            var cities = await _locationsService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities)
                Cities.Add(new CityViewModel(city));
        }

        [RelayCommand]
        public async void LoadCurrentConditions()
        {
            var conditions = await _weatherService.GetCurrentConditions(SelectedCity.Key);
            Weathers.Clear();
            foreach (var condition in conditions)
                Weathers.Add(new WeatherViewModel(condition));
                
        }

        [RelayCommand]
        public async void LoadHistoricalCurrentConditions6h()
        {
            var conditions = await _weatherService.GetHistoricalCurrentConditions6h(SelectedCity.Key);
            Weathers.Clear();
            foreach (var condition in conditions)
                Weathers.Add(new WeatherViewModel(condition));
        }

        [RelayCommand]
        public async void LoadHistoricalCurrentConditions24h()
        {
            var conditions = await _weatherService.GetHistoricalCurrentConditions24h(SelectedCity.Key);
            Weathers.Clear();
            foreach (var condition in conditions)
                Weathers.Add(new WeatherViewModel(condition));
        }

        [RelayCommand]
        public async void LoadForecastFor1Day()
        {
            var condition = await _weatherService.GetDailyForecast(SelectedCity.Key, 1);
            Weathers.Clear();
            Weathers.Add(new WeatherViewModel(condition.DailyForecasts.First()));
        }

        [RelayCommand]
        public async void LoadForecastFor5Days()
        {
            var condition = await _weatherService.GetDailyForecast(SelectedCity.Key, 5);
            Weathers.Clear();
            foreach (var daily in condition.DailyForecasts)
                Weathers.Add(new WeatherViewModel(daily));
        }

        [RelayCommand]
        public async void LoadForecastFor1Hour()
        {
            var conditions = await _weatherService.GetHourlyForecast(SelectedCity.Key, 1);
            Weathers.Clear();
            foreach (var condition in conditions)
                Weathers.Add(new WeatherViewModel(condition));
        }

        [RelayCommand]
        public async void LoadForecastFor12Hours()
        {
            var conditions = await _weatherService.GetHourlyForecast(SelectedCity.Key, 12);
            Weathers.Clear();
            foreach (var condition in conditions)
                Weathers.Add(new WeatherViewModel(condition));
        }

        [RelayCommand]
        public void OpenBookStoreWindow()
        {
            BookStoreView shopProductsView = _serviceProvider.GetService<BookStoreView>();
            BooksViewModel productsViewModel = _serviceProvider.GetService<BooksViewModel>();

            shopProductsView.Show();
            productsViewModel.GetProducts();
        }
    }
}
