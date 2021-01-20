using FlightSearch.Data.EF;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FlightSearch.Data.DataAccess
{
    public class FlightSearchDataAccess
    {
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
    }
}
