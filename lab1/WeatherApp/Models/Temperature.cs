﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal class Temperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }

    }

    internal class RealFeelTemperature {

        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
}