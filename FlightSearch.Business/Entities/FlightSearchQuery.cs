using System;

namespace FlightSearch.Business.Entities
{
    public class FlightSearchQuery
    {
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
