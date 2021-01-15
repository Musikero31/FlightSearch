using AutoMapper;

namespace FlightSearch.Web.Configuration
{
    public static class WebMapper
    {
        public static IMapper Mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<BusinessWebProfile>();
                });

                return config.CreateMapper();
            }
        }
    }
}