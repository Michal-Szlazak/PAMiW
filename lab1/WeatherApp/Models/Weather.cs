using System;
using System.Collections.Generic;

namespace WeatherApp.Models
{
    internal class Weather
    {
        public DateTime LocalObservationDateTime { get; set; }
        public required int EpochTime { get; set; }
        public required string WeatherText { get; set; }
        public required int WeatherIcon { get; set; }
        public required bool HasPrecipitation { get; set; }
        public required object PrecipitationType { get; set; }
        public required bool IsDayTime { get; set; }
        public required Temperature Temperature { get; set; }
        public required string MobileLink { get; set; }
        public required string Link { get; set; }
        public List<DailyForecasts>? DailyForecasts { get; set; }

        public override string ToString()
        {
            return Convert.ToString(
                "Date: " + LocalObservationDateTime.ToString("dd-MM-yyy hh:mm") +
                "\nDescription: " + WeatherText +
                "\nTemp: " + Temperature.Metric.Value + Temperature.Metric.Unit
                );
        }
    }
}
