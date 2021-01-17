using System.Collections.Generic;

namespace FlightSearch.Business.Entities
{
    public class AirlineTwo
    {
        public string[] CarrierCodes { get; set; }
        public int ID { get; set; }
        public List<AirlineOne> Results { get; set; }
    }
}
