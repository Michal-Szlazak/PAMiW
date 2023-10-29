namespace WeatherApp.Models
{
    public class Wind
    {
        public Speed Speed;
    }

    public class Speed
    {
        public double Value;
        public string? Unit;
        public int UnitType;
        public Metric? Metric {  get; set; }
        public Imperial? Imperial { get; set; }
    }
}