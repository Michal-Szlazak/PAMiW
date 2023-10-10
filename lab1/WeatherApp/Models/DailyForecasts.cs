

namespace WeatherApp.Models {

    internal class DailyForecasts {

        public string date { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
    }

}