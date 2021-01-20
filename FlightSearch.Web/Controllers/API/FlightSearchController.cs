using FlightSearch.Business.Components;
using FlightSearch.Business.Entities;
using FlightSearch.Web.Configuration;
using FlightSearch.Web.Models;
using System.Linq;
using System.Web.Http;

namespace FlightSearch.Web.Controllers.API
{
    public class FlightSearchController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTimeTable()
        {
            FlightComponent comp = new FlightComponent();
            var result = comp.GetTimeTables();

            return Ok(new
            {
                data = result.Select(flight => WebMapper.Mapper.Map<TimeTableViewModel>(flight)).ToList()
            });
        }

        [HttpGet]
        public IHttpActionResult AirlineOne(QueryViewModel query)
        {
            FlightComponent component = new FlightComponent();
            var result = component.GetSearchAirlineOne(WebMapper.Mapper.Map<FlightSearchQuery>(query));

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult AirlineTwo(QueryViewModel query)
        {
            FlightComponent component = new FlightComponent();
            var result = component.GetSearchAirlineTwo(WebMapper.Mapper.Map<FlightSearchQuery>(query));

            return Ok(result);
        }
    }
}
