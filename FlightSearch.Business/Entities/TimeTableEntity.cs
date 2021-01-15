using System;

namespace FlightSearch.Business.Entities
{
    public class TimeTableEntity
    {
        public int ID { get; set; }
        public DateTime FlightDate { get; set; }
        public int ScheduleID { get; set; }
        public bool IsActive { get; set; }

        public string Airline { get; set; }
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }

    }
}
