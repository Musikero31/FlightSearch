using System;

namespace FlightSearch.Web.Models
{
    public class SearchFlightViewModel
    {
        public int ID { get; set; }
        public string Airline { get; set; }
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public TimeSpan InboundFlightDuration { get; set; }
        public TimeSpan OutboundFlightDuration { get; set; }
        public int Stops { get; set; }
        public decimal Amount { get; set; }
    }
}