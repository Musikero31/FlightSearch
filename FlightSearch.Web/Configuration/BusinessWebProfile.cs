using AutoMapper;
using FlightSearch.Business.Entities;
using FlightSearch.Web.Models;

namespace FlightSearch.Web.Configuration
{
    public class BusinessWebProfile : Profile
    {
        public BusinessWebProfile()
        {
            CreateMap<AirlineViewModel, AirlineEntity>()
                .ReverseMap();
            CreateMap<AirportEntity, AirportViewModel>()
                .ReverseMap();
            CreateMap<TimeTableEntity, TimeTableViewModel>()
                .ReverseMap();
            CreateMap<FlightSearchQuery, QueryViewModel>()
                .ReverseMap();
        }
    }
}