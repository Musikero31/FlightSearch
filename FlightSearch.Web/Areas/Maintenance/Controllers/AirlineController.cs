using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightSearch.Web.Areas.Maintenance.Controllers
{
    public class AirlineController : Controller
    {
        // GET: Maintenance/Airline
        public ActionResult Index()
        {
            return View();
        }
    }
}