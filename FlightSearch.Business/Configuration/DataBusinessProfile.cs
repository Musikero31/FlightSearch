using AutoMapper;
using FlightSearch.Business.Entities;
using FlightSearch.Data.EF.Entities;
using System;

namespace FlightSearch.Business.Configuration
{
    public class DataBusinessProfile : Profile
    {
        public DataBusinessProfile()
        {
            CreateMap<Airports, AirportEntity>().ReverseMap();
            CreateMap<Airlines, AirlineEntity>().ReverseMap();
            CreateMap<TimeTables, TimeTableEntity>().ReverseMap();
            CreateMap<AirlineSchedules, AirlineScheduleEntity>().ReverseMap();
        }

    }
}
