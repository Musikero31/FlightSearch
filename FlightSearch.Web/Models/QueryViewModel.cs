using System;

namespace FlightSearch.Web.Models
{
    public class QueryViewModel
    {
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}