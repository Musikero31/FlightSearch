using System;

namespace FlightSearch.Business.Entities
{
    public class AirlineScheduleEntity
    {
        public int ID { get; set; }
        public int AirlineID { get; set; }
        public int FromAirportID { get; set; }
        public int ToAirportID { get; set; }
        public string Frequency { get; set; }
        public TimeSpan Duration { get; set; }
        public int Stops { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
