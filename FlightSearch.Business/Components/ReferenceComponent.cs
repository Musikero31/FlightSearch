using FlightSearch.Business.Entities;
using FlightSearch.Business.Utilities;
using FlightSearch.Data.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightSearch.Business.Components
{
    public class ReferenceComponent
    {   
        public Task<List<AirlineEntity>> GetAllAirlinesAsync()
        {            
            return Task.Run(() =>
            {
                AirlineDataAccess data = new AirlineDataAccess();
                var result = data.GetAllAirlines();
                return result.Select(al => GenericHelper.BusinessMapper.Map<AirlineEntity>(al)).ToList();
            });
        }

        public Task<List<AirportEntity>> GetAllAirportsAsync()
        {
            return Task.Run(() =>
            {
                AirportDataAccess data = new AirportDataAccess();
                var result = data.GetAllAirports();
                return result.Select(ap => GenericHelper.BusinessMapper.Map<AirportEntity>(ap)).ToList();
            });
        }
    }
}
