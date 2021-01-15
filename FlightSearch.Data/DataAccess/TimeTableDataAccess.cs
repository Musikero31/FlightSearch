using FlightSearch.Data.EF;
using FlightSearch.Data.EF.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Data.DataAccess
{
    public class TimeTableDataAccess
    {
        public IEnumerable<TimeTables> GetTimeTables()
        {
            IEnumerable<TimeTables> result = null;

            using (var context = new FlightSearchContext())
            {
                result = context.TimeTables.Where(time => time.IsActive).ToList();
            }

            return result;
        }

        public int AddTimeTable(TimeTables entity)
        {
            using (var context = new FlightSearchContext())
            {
                context.TimeTables.Add(entity);
                context.SaveChanges();
            }

            return entity.ID;
        }
    }
}
