using AutoMapper;
using FlightSearch.Business.Entities;
using FlightSearch.Data.EF.Entities;

namespace FlightSearch.Business.Configuration
{
    public class DataBusinessProfile : Profile
    {
        public DataBusinessProfile()
        {
            CreateMap<Airlines, AirlineEntity>()
                .ReverseMap();
        }
    }
}
