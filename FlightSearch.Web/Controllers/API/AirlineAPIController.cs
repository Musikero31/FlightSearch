using FlightSearch.Business.Components.Maintenance;
using FlightSearch.Business.Entities;
using FlightSearch.Web.Configuration;
using FlightSearch.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FlightSearch.Web.Controllers.API
{
    public class AirlineAPIController : ApiController
    {
        private readonly AirlineComponent _component = new AirlineComponent();

        // GET api/<controller>
        public List<AirlineViewModel> Get()
        {
            var result = _component.Get();

            return result.Select(airline => WebMapper.Mapper.Map<AirlineViewModel>(airline))
                .ToList();
        }

        // GET api/<controller>/5
        public AirlineViewModel Get(int id)
        {
            var result = _component.GetAirlineById(id);

            return WebMapper.Mapper.Map<AirlineViewModel>(result);
        }

        // POST api/<controller>
        public void Post([FromBody] AirlineViewModel value)
        {
            var data = WebMapper.Mapper.Map<AirlineEntity>(value);

            _component.CreateNewArline(data);
        }

        // PUT api/<controller>/5
        public void Put([FromBody] AirlineViewModel value)
        {
            var data = WebMapper.Mapper.Map<AirlineEntity>(value);

            _component.UpdateAirline(data);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _component.DeleteAirline(id);
        }
    }
}