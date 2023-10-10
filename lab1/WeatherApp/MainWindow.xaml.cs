using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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

        private async void btnGetLocationClicked(object sender, RoutedEventArgs e) {

            City[] cities= await locationService.GetLocations(cityTextBox.Text);
            cityListBox.ItemsSource = cities;
        }

        private async void btnGetCurrentConditionClicked(object sender, RoutedEventArgs e) {

            var selectedCity= (City)cityListBox.SelectedItem;
            if(selectedCity != null)
            {
                var weather = await weatherService.GetCurrentConditions(selectedCity.Key);
                double tempValue = weather.Temperature.Metric.Value;
                weatherListBox.Items.Add(selectedCity.LocalizedName + " " + Convert.ToString(tempValue));
            }
        }

        private async void btnGetHistoricalCurrentConditions(object sender, RoutedEventArgs e) {
            //TODO
        }

        private async void btnGetForecastFor1DayClicked(object sender, RoutedEventArgs e) {

            var selectedCity= (City)cityListBox.SelectedItem;

            if(selectedCity != null)
            {
                var weather = await weatherService.GetDailyForecast(selectedCity.Key, 1);
                List<DailyForecasts> dailyForecasts = weather.DailyForecasts;

                foreach (var dailyForecast in dailyForecasts)
                {
                    string info = Convert.ToString(
                        "Date: " + dailyForecast.date +
                        "; Max: " + dailyForecast.Temperature.Maximum.Value + dailyForecast.Temperature.Maximum.Unit +
                        "; Min: " + dailyForecast.Temperature.Minimum.Value
                        );
                    weatherListBox.Items.Add(info);
                }
            }

        }
    }
}
