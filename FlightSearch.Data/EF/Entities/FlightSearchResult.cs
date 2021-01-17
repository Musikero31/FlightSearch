using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSearch.Data.EF.Entities
{
    public class FlightSearchResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime FlightDate { get; set; }
        public string AirlineLogo { get; set; }
        public string AirlineName { get; set; }
        public string InboundFlight { get; set; }
        public TimeSpan InboundFlightDuration { get; set; }
        public string OutboundFlight { get; set; }
        public TimeSpan OutboundFlightDuration { get; set; }
        public int Stops { get; set; }
        public decimal Amount { get; set; }

    }
}
