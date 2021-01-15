using FlightSearch.Data.EF;
using FlightSearch.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Data.DataAccess
{
    public class ScheduleDataAccess
    {
        public IEnumerable<AirlineSchedules> GetAllSchedules()
        {
            IEnumerable<AirlineSchedules> result = null;

            using (var context = new FlightSearchContext())
            {
                result = context.AirlineSchedules.Where(sch => sch.IsActive).ToList();
            }

            return result;
        }

        public IEnumerable<AirlineSchedules> GetSchedulesByAirlines(int airlineID)
        {
            IEnumerable<AirlineSchedules> result = null;

            using (var context = new FlightSearchContext())
            {
                result = context.AirlineSchedules.Where(sch => sch.AirlineID == airlineID)
                    .Where(sch => sch.IsActive).ToList();
            }

            return result;
        }
    }
}
