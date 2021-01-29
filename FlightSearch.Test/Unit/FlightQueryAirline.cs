using FlightSearch.Business.Entities;

namespace FlightSearch.Test.Unit
{
    public class FlightQueryAirline: ITestParameters
    {
        public FlightSearchQuery Query { get; set; }
        public object ExpectedResult { get; set; }
    }
}
