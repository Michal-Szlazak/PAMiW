namespace WeatherApp.Models
{
    internal class Wind
    {
        public Speed Speed;
    }

    internal class Speed
    {
        public double Value;
        public string? Unit;
        public int UnitType;
        public Metric? Metric {  get; set; }
        public Imperial? Imperial { get; set; }
    }
}