using System;
using System.Collections.Generic;
using System.Linq;
namespace WeatherApp.Models
{
    internal class Temperature
    {
        public Metric? Metric { get; set; }
        public Imperial? Imperial { get; set; }
        public Minimum? Minimum { get; set; }
        public Maximum? Maximum { get; set; }
        public double Value { get; set; }
        public string? Unit {  get; set; }
        public int UnitType { get; set; }

    }

    internal class RealFeelTemperature {
        public Metric? Metric { get; set; }
        public Imperial? Imperial { get; set; }
        public Minimum? Minimum { get; set; }
        public Maximum? Maximum { get; set; }
        public double Value { get; set; }
        public string? Unit { get; set; }
        public int UnitType { get; set; }
    }
}
