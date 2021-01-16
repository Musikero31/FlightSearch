using NLog;
using System;
using System.Data.Entity.Validation;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FlightSearch.Web
{
    public class MvcApplication : HttpApplication
    {
        private static readonly Logger _log = LogManager.GetLogger("DebugLoggerRules");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            _log.Error(ex, "Exception occurred! Please see ERROR log file");

            if (ex.InnerException != null)
            {
                _log.Error(ex.InnerException, "Inner exception occurred!");
            }

            if (ex is DbEntityValidationException)
            {
                var validationEx = ex as DbEntityValidationException;
                foreach (var validationErrors in validationEx.EntityValidationErrors)
                {
                    foreach (var entityErrors in validationErrors.ValidationErrors)
                    {
                        _log.Error("ENTITY VALIDATION ERRORS:");
                        _log.Error(validationEx, $"Class : {validationErrors.Entry.Entity.GetType().FullName}, " +
                            $"Property : {entityErrors.PropertyName}, " +
                            $"Error: {entityErrors.ErrorMessage}");
                    }
                }

            }
        }

    }
}
