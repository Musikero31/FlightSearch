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
        public int ScheduleID { get; set; }
        public bool IsActive { get; set; }
    }
}
