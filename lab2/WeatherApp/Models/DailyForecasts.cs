using System;

namespace WeatherApp.Models {

    public class DailyForecasts {

        public DateTime date { get; set; }
        public required Temperature Temperature { get; set; }
        public required RealFeelTemperature RealFeelTemperature { get; set; }
        public required Day Day;

        public override string ToString()
        {
            return Convert.ToString(
                        "Date: " + date.ToString("dd-MM-yyyy") +
                        "\nMax: " + Temperature.Maximum.Value + Temperature.Maximum.Unit +
                        " Min: " + Temperature.Minimum.Value + Temperature.Minimum.Unit +
                        "\nMaxRealFeel: " + RealFeelTemperature.Maximum.Value + RealFeelTemperature.Maximum.Unit +
                        " MinRealFeel: " + RealFeelTemperature.Minimum.Value + RealFeelTemperature.Minimum.Unit +
                        "\nWind: " + Day.Wind.Speed.Value + Day.Wind.Speed.Unit +
                        " Rain: " + Day.Rain.Value + Day.Rain.Unit +
                        "\nDescription: " + Day.ShortPhrase
                        ); ;
        }

    }

}