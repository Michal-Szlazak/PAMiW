namespace WeatherApp.Models
{
    internal class Maximum
    {
        public double Value { get; set; }
        public string? Unit { get; set; }
        public int UnitType { get; set; }
        public Metric? Metric { get; set; }
        public Imperial? Imperial { get; set; }
    }
}