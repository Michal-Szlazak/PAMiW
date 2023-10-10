﻿namespace WeatherApp.Models
{
    internal class Metric
    {
        public double Value { get; set; }
        public required string Unit { get; set; }
        public int UnitType { get; set; }
    }
}
