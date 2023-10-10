using System;

namespace WeatherApp.Models
{
    internal class HistoricalForecast
    {
        public DateTime LocalObservationDateTime;
        public required string WeatherText { get; set; }
        public required Temperature Temperature { get; set; }
        public required RealFeelTemperature RealFeelTemperature { get; set; }
        public required Wind Wind { get; set; }
        public int CloudCover;
        public required Pressure Pressure;
        public required ApparentTemperature ApparentTemperature { get; set; }
        public required TemperatureSummary TemperatureSummary { get; set; }

        public override string ToString()
        {
            return Convert.ToString(
                        "Date: " + LocalObservationDateTime.ToString("dd-MM-yyyy HH:mm") +
                        "\nTemp: " + Temperature.Metric.Value + Temperature.Metric.Unit +
                        " RealFeelTemp: " + RealFeelTemperature.Metric.Value + RealFeelTemperature.Metric.Unit +
                        "\nWind: " + Wind.Speed.Metric.Value + Wind.Speed.Metric.Unit +
                        "\nDescription: " + WeatherText +
                        "\nCloud cover: " + CloudCover + 
                        " Pressure: " + Pressure.Metric.Value + Pressure.Metric.Unit +
                        "\nApparent Temp: " + ApparentTemperature.Metric.Value + ApparentTemperature.Metric.Unit +
                        "\nTemperature summary past 6h: " +
                        "\nMax: " + TemperatureSummary.Past6HourRange.Maximum.Metric.Value + TemperatureSummary.Past6HourRange.Maximum.Metric.Unit +
                        " Min: " + TemperatureSummary.Past6HourRange.Minimum.Metric.Value + TemperatureSummary.Past6HourRange.Minimum.Metric.Unit +
                        "\nTemperature summary past 6h: " +
                        "\nMax: " + TemperatureSummary.Past24HourRange.Maximum.Metric.Value + TemperatureSummary.Past24HourRange.Maximum.Metric.Unit +
                        " Min: " + TemperatureSummary.Past24HourRange.Minimum.Metric.Value + TemperatureSummary.Past24HourRange.Minimum.Metric.Unit
                        ) ;
        }
    }

    internal class ApparentTemperature
    {
        public required Metric Metric { get; set; }
        public required Imperial Imperial { get; set; }
    }

    internal class TemperatureSummary
    {
        public required Past6HourRange Past6HourRange { get; set; }
        public required Past24HourRange Past24HourRange { get; set; }
    }

    internal class Past6HourRange
    {
        public required Maximum Maximum { get; set; }
        public required Minimum Minimum { get; set;}
    }

    internal class Past24HourRange
    {
        public required Maximum Maximum { get; set; }
        public required Minimum Minimum { get; set; }
    }
}
