using FlightSearch.Business.Components;
using FlightSearch.Web.Configuration;
using FlightSearch.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FlightSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public async Task<ActionResult> LoadData()
        {
            await PopulateReferences();

            return View();
        }

        public async Task<ActionResult> AirlineSearch()
        {
            await PopulateReferences();

            return View();
        }

        [HttpGet]
        public ActionResult GetAllAirlines()
        {
            ReferenceComponent comp = new ReferenceComponent();
            var result = comp.GetAllAirlinesAsync().Result;

            return Json(new
            {
                data = result.Select(al => WebMapper.Mapper.Map<AirlineViewModel>(al)).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTimeTable()
        {
            FlightComponent comp = new FlightComponent();
            var result = comp.GetTimeTables();

            return Json(new
            {
                data = result.Select(f => WebMapper.Mapper.Map<TimeTableViewModel>(f)).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GenerateTimeTable(int airlineID, DateTime fromDate, DateTime toDate)
        {
            FlightComponent comp = new FlightComponent();
            comp.GenerateFlights(airlineID, fromDate, toDate);

            return Json(true);
        }

        private async Task PopulateReferences()
        {
            ReferenceComponent refComp = new ReferenceComponent();
            var airlines = await refComp.GetAllAirlinesAsync();
            ViewData["Airlines"] = airlines.Select(al => WebMapper.Mapper.Map<AirlineViewModel>(al)).ToList();
        }
    }
}