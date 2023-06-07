using FlightSearch.Business.Components.Maintenance;
using FlightSearch.Web.Configuration;
using FlightSearch.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}