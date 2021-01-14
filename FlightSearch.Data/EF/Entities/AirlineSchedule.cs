using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Data.EF.Entities
{
    [Table("AirlineSchedules")]
    public partial class AirlineSchedules
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
