using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class Day
    {
        public required string ShortPhrase;
        public required string LongPhrase;
        public required Wind Wind;
        public required Rain Rain;
    }
}
