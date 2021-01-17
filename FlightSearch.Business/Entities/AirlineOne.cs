using System;

namespace FlightSearch.Business.Entities
{
    public class AirlineOne
    {
        public string AirlineLogoAddress { get; set; }
        public string AirlineName { get; set; }
        public TimeSpan InboundFlightDuration { get; set; }
        public string IteneraryID { get; set; }
        public TimeSpan OutboundFlightDuration { get; set; }
        public int Stops { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
