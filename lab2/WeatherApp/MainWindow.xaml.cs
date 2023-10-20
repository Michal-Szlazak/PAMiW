using System.Collections.Generic;
using System.Windows;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {

        LocationService locationService;
        WeatherService weatherService;
        public MainWindow()
        {
            InitializeComponent();
            locationService = new LocationService();
            weatherService = new WeatherService();
        }

        private async void btnAutocompleteClicked(object sender, RoutedEventArgs e)
        {
            City? autocomplete = await locationService.GetAutocomplete(cityTextBox.Text);
            if(autocomplete != null) {
                cityTextBox.Text = autocomplete.LocalizedName;
            }
        }

        private async void btnGetLocationClicked(object sender, RoutedEventArgs e) {

            City[]? cities= await locationService.GetLocations(cityTextBox.Text);
            if(cities != null)
            {
                cityListBox.ItemsSource = cities;
            }
        }

        private async void btnGetCurrentConditionClicked(object sender, RoutedEventArgs e) {

            var selectedCity = (City)cityListBox.SelectedItem;
            if(selectedCity != null)
            {
                List<Weather>? weathers = await weatherService.GetCurrentConditions(selectedCity.Key);
                if(weathers != null)
                {
                    weatherListBox.ItemsSource = weathers;
                }
            }
        }

        private async void btnGetHistoricalCurrentConditions6hClicked(object sender, RoutedEventArgs e) {

            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HistoricalForecast>? historicalForecasts =
                    await weatherService.GetHistoricalCurrentConditions6h(selectedCity.Key);
                if(historicalForecasts != null)
                {
                    weatherListBox.ItemsSource = historicalForecasts;
                }
            }
        }

        private async void btnGetHistoricalCurrentConditions24hClicked(object sender, RoutedEventArgs e)
        {

            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HistoricalForecast>? historicalForecasts = 
                    await weatherService.GetHistoricalCurrentConditions24h(selectedCity.Key);
                if(historicalForecasts != null)
                {
                    weatherListBox.ItemsSource = historicalForecasts;
                }
            }
        }

        private async void btnGetForecastFor1DayClicked(object sender, RoutedEventArgs e) {

            var selectedCity= (City)cityListBox.SelectedItem;

            if(selectedCity != null)
            {
                Weather? weather = await weatherService.GetDailyForecast(selectedCity.Key, 1);
                if(weather != null)
                {
                    List<DailyForecasts>? dailyForecasts = weather.DailyForecasts;
                    weatherListBox.ItemsSource = dailyForecasts;
                }
            }
        }

        private async void btnGetForecastFor5DaysClicked(object sender, RoutedEventArgs e)
        {

            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                Weather? weather = await weatherService.GetDailyForecast(selectedCity.Key, 5);
                if(weather != null && weather.DailyForecasts != null)
                {
                    weatherListBox.ItemsSource = weather.DailyForecasts;
                }
            }

        }

        private async void btnGetForecastFor1HourClicked(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HourlyForecasts>? hourlyForecasts = await weatherService.GetHourlyForecast(selectedCity.Key, 1);
                if(hourlyForecasts != null)
                {
                    weatherListBox.ItemsSource = hourlyForecasts;
                }
            }
        }

        private async void btnGetForecastFor12HoursClicked(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HourlyForecasts>? hourlyForecasts = await weatherService.GetHourlyForecast(selectedCity.Key, 12);
                if(hourlyForecasts != null)
                {
                    weatherListBox.ItemsSource = hourlyForecasts;
                }
            }
        }
    }
}
