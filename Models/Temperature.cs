namespace WeatherizeMe.Models
{
    public class TemperatureLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Temperature { get; set; }
        public User User { get; set; }
    }
}
