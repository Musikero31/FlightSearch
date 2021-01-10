using AutoMapper;
using FlightSearch.Business.Configuration;
using FlightSearch.Business.Entities;
using FlightSearch.Data.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Business
{
    public class AirlineComponent
    {
        public IMapper Mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DataBusinessProfile>();
                });

                return config.CreateMapper();
            }
        }
        
        public List<AirlineEntity> GetAllAirlines()
        {
            AirlineDataAccess data = new AirlineDataAccess();
            var result = data.GetAllAirlines();
            return result.Select(al => Mapper.Map<AirlineEntity>(al)).ToList();
        }
    }
}
