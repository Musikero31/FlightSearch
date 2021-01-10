using AutoMapper;
using FlightSearch.Business.Entities;
using FlightSearch.Data.EF;

namespace FlightSearch.Business.Configuration
{
    public class DataBusinessProfile : Profile
    {
        public DataBusinessProfile()
        {
            CreateMap<Airline, AirlineEntity>()
                .ReverseMap();
        }
    }
}
