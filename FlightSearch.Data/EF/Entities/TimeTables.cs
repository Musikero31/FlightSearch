﻿using System;
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
        public int AirlineID { get; set; }
        public int FromAirportID { get; set; }
        public int ToAirportID { get; set; }
        public TimeSpan Duration { get; set; }
        public int Stops { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
    }
}
