using AutoMapper;
using FlightSearch.Web.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FlightSearch.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var config = new MapperConfiguration(profile =>
            //{
            //    profile.AddProfile<FlightSearchMapperProfile>();
            //});

            //config.CompileMappings();
        }
    }
}
