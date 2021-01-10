using AutoMapper;
using FlightSearch.Business;
using FlightSearch.Web.Configuration;
using FlightSearch.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightSearch.Web.Controllers
{
    public class HomeController : Controller
    {
        public IMapper Mapper
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult GetAllAirlines()
        {
            AirlineComponent comp = new AirlineComponent();

            return Json(new
            {
                data = comp.GetAllAirlines().Select(al => Mapper.Map<AirlineViewModel>(al)).ToList()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}