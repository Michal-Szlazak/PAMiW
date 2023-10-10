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
            City autocomplete = await locationService.GetAutocomplete(cityTextBox.Text);
            if(autocomplete != null) {
                cityTextBox.Text = autocomplete.LocalizedName;
            }
        }

        private async void btnGetLocationClicked(object sender, RoutedEventArgs e) {

            City[] cities= await locationService.GetLocations(cityTextBox.Text);
            cityListBox.ItemsSource = cities;
        }

        private async void btnGetCurrentConditionClicked(object sender, RoutedEventArgs e) {

            var selectedCity= (City)cityListBox.SelectedItem;
            if(selectedCity != null)
            {
                List<Weather> weathers = await weatherService.GetCurrentConditions(selectedCity.Key);
                weatherListBox.ItemsSource = weathers;
            }
        }

        private async void btnGetHistoricalCurrentConditions6hClicked(object sender, RoutedEventArgs e) {

            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HistoricalForecast> historicalForecasts = await weatherService.GetHistoricalCurrentConditions6h(selectedCity.Key);
                weatherListBox.ItemsSource = historicalForecasts;
            }
        }

        private async void btnGetHistoricalCurrentConditions24hClicked(object sender, RoutedEventArgs e)
        {

            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HistoricalForecast> historicalForecasts = await weatherService.GetHistoricalCurrentConditions24h(selectedCity.Key);
                weatherListBox.ItemsSource = historicalForecasts;
            }
        }

        private async void btnGetForecastFor1DayClicked(object sender, RoutedEventArgs e) {

            var selectedCity= (City)cityListBox.SelectedItem;

            if(selectedCity != null)
            {
                var weather = await weatherService.GetDailyForecast(selectedCity.Key, 1);
                List<DailyForecasts> dailyForecasts = weather.DailyForecasts;
                weatherListBox.ItemsSource = dailyForecasts;
            }
        }

        private async void btnGetForecastFor5DaysClicked(object sender, RoutedEventArgs e)
        {

            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                var weather = await weatherService.GetDailyForecast(selectedCity.Key, 5);
                List<DailyForecasts> dailyForecasts = weather.DailyForecasts;
                weatherListBox.ItemsSource = dailyForecasts;
            }

        }

        private async void btnGetForecastFor1HourClicked(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HourlyForecasts> hourlyForecasts = await weatherService.GetHourlyForecast(selectedCity.Key, 1);
                weatherListBox.ItemsSource = hourlyForecasts;
            }
        }

        private async void btnGetForecastFor12HoursClicked(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)cityListBox.SelectedItem;

            if (selectedCity != null)
            {
                List<HourlyForecasts> hourlyForecasts = await weatherService.GetHourlyForecast(selectedCity.Key, 12);
                weatherListBox.ItemsSource = hourlyForecasts;
            }
        }
    }
}
