using System;

namespace WeatherApp.Models
{
    internal class City
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string? LocalizedName { get; set; }
        public Country? Country { get; set; }
        public AdministrativeArea? AdministrativeArea { get; set; }

        public override string ToString()
        {
            return Convert.ToString(
                LocalizedName + ", " +  
                Country.LocalizedName + ", " +
                AdministrativeArea.LocalizedName
                );
        }
    }
}
