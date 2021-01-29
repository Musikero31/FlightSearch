using FlightSearch.Business.Components;
using FlightSearch.Business.Entities;
using System;
using Xunit;

namespace FlightSearch.Test.Unit
{
    public class FlightComponentTest
    {
        [Theory]
        [ClassData(typeof(FlightSearchAirlineOneData))]
        public void GetSearchAirlineOne_ShouldReturnRows(ITestParameters query)
        {
            var param = (FlightQueryAirline)query;
            bool expected = Convert.ToBoolean(param.ExpectedResult);

            FlightComponent component = new FlightComponent();
            var result = component.GetSearchAirlineOne(param.Query);

            Assert.Equal(expected, result.Count > 0);
        }

        [Theory]
        [ClassData(typeof(FlightSearchAirlineTwoData))]
        public void GetSearchAirlineTwo_ShouldHaveTheSameCarrierCodes(ITestParameters query)
        {
            var param = (FlightQueryAirline)query;
            int expected = Convert.ToInt32(param.ExpectedResult);

            FlightComponent component = new FlightComponent();
            var result = component.GetSearchAirlineTwo(param.Query);

            Assert.Equal(expected, result.CarrierCodes.Count);
        }

        [Fact]
        public void GetSearchAirlineOne_SameAirportThrowsError()
        {
            FlightSearchQuery query = new FlightSearchQuery
            {
                DepartureDate = DateTime.Parse("Jan 18, 2021"),
                ArrivalDate = DateTime.Parse("Jan 31, 2021"),
                FromAirport = "KUL",
                ToAirport = "KUL"
            };

            FlightComponent component = new FlightComponent();
            Assert.Throws<ArgumentException>("FromAirport, TwoAirport", () => component.GetSearchAirlineOne(query));
        }

        [Fact]
        public void GetSearchAirlineOne_SameDateThrowsError()
        {
            FlightSearchQuery query = new FlightSearchQuery
            {
                DepartureDate = DateTime.Parse("Jan 31, 2021"),
                ArrivalDate = DateTime.Parse("Jan 31, 2021"),
                FromAirport = "KUL",
                ToAirport = "MNL"
            };

            FlightComponent component = new FlightComponent();
            Assert.Throws<ArgumentException>("DepartureDate, ArrivalDate", () => component.GetSearchAirlineOne(query));
        }
    }
}
