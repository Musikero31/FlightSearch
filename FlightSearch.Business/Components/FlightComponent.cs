using FlightSearch.Business.Entities;
using FlightSearch.Data.DataAccess;
using FlightSearch.Data.EF.Entities;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<AirlineOne> GetSearchAirlineOne(FlightSearchQuery query)
        {
            ValidateSearch(query);

            List<AirlineOne> result = null;

            TimeTableDataAccess dataAccess = new TimeTableDataAccess();
            var data = dataAccess.GetData(query.FromAirport, query.ToAirport, query.DepartureDate, query.ArrivalDate);
            if (data == null)
            {
                return result;
            }

            result = new List<AirlineOne>();
            result = (from DataRow row in data.Rows
                      select new AirlineOne
                      {
                          AirlineLogoAddress = row["AirlineLogo"].ToString(),
                          AirlineName = row["AirlineName"].ToString(),
                          InboundFlightDuration = TimeSpan.Parse(row["InboundFlightDuration"].ToString()),
                          IteneraryID = null,
                          OutboundFlightDuration = TimeSpan.Parse(row["OutboundFlightDuration"].ToString()),
                          Stops = Convert.ToInt32(row["Stops"]),
                          TotalAmount = Convert.ToDecimal(row["Amount"])
                      }).ToList();

            _log.Info($"Retrieved result for AirlineOne : {JsonConvert.SerializeObject(result)}");

            return result;
        }

        public AirlineTwo GetSearchAirlineTwo(FlightSearchQuery query)
        {
            ValidateSearch(query);

            AirlineTwo result = null;

            TimeTableDataAccess dataAccess = new TimeTableDataAccess();
            var data = dataAccess.GetData(query.FromAirport, query.ToAirport, query.DepartureDate, query.ArrivalDate);
            
            if (data == null)
            {
                return result;
            }

            List<string> carrierCodes = (from DataRow row in data.Rows
                                         select row["CarrierCode"].ToString()).Distinct().ToList();

            List<AirlineOne> innerResult = (from DataRow row in data.Rows
                                            select new AirlineOne
                                            {
                                                AirlineLogoAddress = row["AirlineLogo"].ToString(),
                                                AirlineName = row["AirlineName"].ToString(),
                                                InboundFlightDuration = TimeSpan.Parse(row["InboundFlightDuration"].ToString()),
                                                IteneraryID = null,
                                                OutboundFlightDuration = TimeSpan.Parse(row["OutboundFlightDuration"].ToString()),
                                                Stops = Convert.ToInt32(row["Stops"]),
                                                TotalAmount = Convert.ToDecimal(row["Amount"])
                                            }).ToList();
            result = new AirlineTwo
            {
                CarrierCodes = new List<string>(carrierCodes),
                Results = new List<AirlineOne>(innerResult)
            };

            _log.Info($"Retrieved result for AirlineTwo : {JsonConvert.SerializeObject(result)}");

            return result;
        }

        public void ClearTimeTables()
        {
            TimeTableDataAccess dataAccess = new TimeTableDataAccess();
            dataAccess.ResetTimeTables();
        }

        private void ValidateSearch(FlightSearchQuery query)
        {
            if (query.FromAirport == query.ToAirport)
            {
                throw new ArgumentException("Airports cannot be the same", "FromAirport, TwoAirport");
            }

            if (query.DepartureDate == query.ArrivalDate)
            {
                throw new ArgumentException("Departure date and Arrival date cannot be the same", "DepartureDate, ArrivalDate");
            }

            if (query.DepartureDate > query.ArrivalDate)
            {
                throw new ArgumentException("Departure date should be less than Arrival date", "DepartureDate");
            }

            if (query.ArrivalDate < query.DepartureDate)
            {
                throw new ArgumentException("Arrival date should be greater than Departure date", "ArrivalDate");
            }
        }
    }
}
