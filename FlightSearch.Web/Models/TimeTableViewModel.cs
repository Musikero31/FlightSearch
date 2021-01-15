using System;

namespace FlightSearch.Web.Models
{
    public class TimeTableViewModel
    {
        public int ID { get; set; }
        public string Airline { get; set; }
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public DateTime FlightDate { get; set; }
    }
}