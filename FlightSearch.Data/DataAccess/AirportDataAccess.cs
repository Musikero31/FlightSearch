using FlightSearch.Data.EF;
using FlightSearch.Data.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Data.DataAccess
{
    public class AirportDataAccess
    {
        public IEnumerable<Airports> GetAllAirports()
        {
            IEnumerable<Airports> result = null;

            using (var context = new FlightSearchContext())
            {
                result = context.Airports.Where(ap => ap.IsActive).ToList();
            }

            return result;
        }
    }
}
