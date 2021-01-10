using FlightSearch.Data.EF;
using FlightSearch.Data.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Data.DataAccess
{
    public class AirlineDataAccess
    {
        public IEnumerable<Airlines> GetAllAirlines()
        {
            IEnumerable<Airlines> result = null;

            using (var context = new FlightSearchContext())
            {
                result = context.Airlines.Where(al => al.IsActive).ToList();
            }

            return result;
        }
    }
}
