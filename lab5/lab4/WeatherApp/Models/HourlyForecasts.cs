using System;

namespace WeatherApp.Models
{
    public class HourlyForecasts
    {
        public DateTime DateTime { get; set; }
        public string IconPhrase { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public Wind Wind { get; set; }
        public Rain Rain { get; set; }

        public override string ToString()
        {
            return Convert.ToString(
                        "Date: " + DateTime.ToString("dd-MM-yyyy HH:mm") +
                        "\nTemp: " + Temperature.Value + Temperature.Unit +
                        " RealFeelTemp: " + RealFeelTemperature.Value + RealFeelTemperature.Unit +
                        "\nWind: " + Wind.Speed.Value + Wind.Speed.Unit +
                        " Rain: " + Rain.Value + Rain.Unit +
                        "\nDescription: " + IconPhrase
                        ); ;
        }

    }
}
