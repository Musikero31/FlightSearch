using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightSearch.Data.EF.Entities
{
    public class TimeTables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime FlightDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int FromAirportID { get; set; }

        public int ToAirportID { get; set; }

        public bool IsActive { get; set; }
    }
}
