using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    internal class Pressure
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
}