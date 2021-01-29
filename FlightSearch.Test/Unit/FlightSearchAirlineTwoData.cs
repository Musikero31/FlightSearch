using FlightSearch.Business.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Test.Unit
{
    public class FlightSearchAirlineTwoData : IEnumerable<object[]>
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
                        ArrivalDate = DateTime.Parse("Jan 31, 2021"),
                        FromAirport = "MNL",
                        ToAirport = "LAX"
                    },
                    ExpectedResult = 2
                }
            };
            yield return new object[]
            {
                new FlightQueryAirline
                {
                    Query = new FlightSearchQuery
                    {
                        DepartureDate = DateTime.Parse("Jan 18, 2021"),
                        ArrivalDate = DateTime.Parse("Jan 31, 2021"),
                        FromAirport = "KUL",
                        ToAirport = "LAX"
                    },
                    ExpectedResult = 0
                }
            };
            yield return new object[]
            {
                new FlightQueryAirline
                {
                    Query = new FlightSearchQuery
                    {
                        DepartureDate = DateTime.Parse("Jan 18, 2021"),
                        ArrivalDate = DateTime.Parse("Jan 31, 2021"),
                        FromAirport = "MNL",
                        ToAirport = "KUL"
                    },
                    ExpectedResult = 3
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
