using FlightSearch.Data.EF;
using FlightSearch.Data.EF.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FlightSearch.Data.DataAccess
{
    public class TimeTableDataAccess
    {
        private static readonly Logger _log = LogManager.GetLogger("DebugLoggerRules");

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

        public DataTable GetData(string fromAirport, string toAirport, DateTime fromDate, DateTime toDate)
        {
            DataTable result = null;

            using (var context = new FlightSearchContext())
            {
                var con = context.Database.Connection;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "SearchFlights";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@FromAirport", fromAirport));
                    cmd.Parameters.Add(new SqlParameter("@ToAirport", toAirport));
                    cmd.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                    cmd.Parameters.Add(new SqlParameter("@ToDate", toDate));

                    using (var reader = cmd.ExecuteReader())
                    {
                        result = new DataTable();
                        result.Load(reader);
                    }
                }

            }

            return result;
        }

        public void ResetTimeTables()
        {
            using (var context = new FlightSearchContext())
            {
                var con = context.Database.Connection;

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = "TRUNCATE TABLE TimeTables; DBCC CHECKIDENT ('TimeTables', RESEED, 1)";
                    cmd.CommandType = CommandType.Text;

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
