using FlightSearch.Data.EF;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Data.DataAccess
{
    public class AirlineDataAccess
    {
        public IEnumerable<Airline> GetAllAirlines()
        {
            IEnumerable<Airline> result = null;

            using (var context = new FlightSearchContext())
            {
                var data = context.Airlines.Where(al => al.IsActive).ToList();
            }

            return result;
        }
    }
}
