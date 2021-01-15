using AutoMapper;
using FlightSearch.Business.Configuration;

namespace FlightSearch.Business.Utilities
{
    public static class GenericHelper
    {
        public static IMapper BusinessMapper
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
        
    }
}
