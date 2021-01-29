using FlightSearch.Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FlightSearch.Test.Unit
{
    public class FlightSearchAirlineOneData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new FlightQueryAirline
                {
                    Query = new FlightSearchQuery
                    {
                        DepartureDate = DateTime.Parse("Jan 18, 2021"),
                        ArrivalDate = DateTime.Parse("Jan 19, 2021"),
                        FromAirport = "MNL",
                        ToAirport = "KUL"
                    },
                    ExpectedResult = true
                }                
            };
            yield return new object[]
            {
                new FlightQueryAirline
                {
                    Query = new FlightSearchQuery
                    {
                        DepartureDate = DateTime.Parse("Jan 18, 2021"),
                        ArrivalDate = DateTime.Parse("Jan 19, 2021"),
                        FromAirport = "KUL",
                        ToAirport = "MNL"
                    },
                    ExpectedResult = true
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
