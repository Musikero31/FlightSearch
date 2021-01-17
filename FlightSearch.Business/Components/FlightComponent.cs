using FlightSearch.Business.Entities;
using FlightSearch.Data.DataAccess;
using FlightSearch.Data.EF.Entities;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Business.Components
{
    public class FlightComponent
    {
        private static readonly Logger _log = LogManager.GetLogger("DebugLoggerRules");

        public void GenerateFlights(int airlineID, DateTime fromDate, DateTime toDate)
        {
            // Get schedule by airline id
            ScheduleDataAccess scheduleData = new ScheduleDataAccess();
            TimeTableDataAccess timeData = new TimeTableDataAccess();

            var schedules = scheduleData.GetSchedulesByAirlines(airlineID);

            for (DateTime counterDate = fromDate; counterDate <= toDate; counterDate = counterDate.AddDays(1))
            {
                foreach (var sched in schedules)
                {
                    var frequencies = sched.Frequency.Split(',').Select(f => Convert.ToInt16(f));
                    if (frequencies.Any(f => Convert.ToInt32(f) == (int)counterDate.DayOfWeek))
                    {
                        TimeTables entity = new TimeTables
                        {
                            FlightDate = counterDate,
                            AirlineID = sched.AirlineID,
                            Amount = sched.Amount,
                            Duration = sched.Duration,
                            FromAirportID = sched.FromAirportID,
                            ToAirportID = sched.ToAirportID,
                            Stops = sched.Stops,
                            IsActive = true
                        };

                        _log.Info($"Adding to TimeTables : {JsonConvert.SerializeObject(entity)}");

                        timeData.AddTimeTable(entity);
                    }

                }
            }
        }

        public List<TimeTableEntity> GetTimeTables()
        {
            List<TimeTableEntity> result = null;
            
            TimeTableDataAccess timeData = new TimeTableDataAccess();
            AirportDataAccess airportData = new AirportDataAccess();
            AirlineDataAccess airlineData = new AirlineDataAccess();

            var timeTables = timeData.GetTimeTables();
            var airlines = airlineData.GetAllAirlines();
            var airports = airportData.GetAllAirports();

            result = (from time in timeTables
                      join line in airlines on time.AirlineID equals line.ID
                      join src in airports on time.FromAirportID equals src.ID
                      join dest in airports on time.ToAirportID equals dest.ID
                      select new TimeTableEntity
                      {
                          ID = time.ID,
                          Airline = line.AirlineName,
                          FlightDate = time.FlightDate,
                          FromAirport = src.Name,
                          ToAirport = dest.Name
                      }).ToList();

            _log.Info($"Data retrieved : {JsonConvert.SerializeObject(result)}");

            return result;
        }
    }
}
