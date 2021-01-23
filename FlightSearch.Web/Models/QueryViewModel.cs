using FlightSearch.Web.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace FlightSearch.Web.Models
{
    public class QueryViewModel
    {
        [Display(Name = "FromAirport", ResourceType = typeof(Resource_EN))]
        public string FromAirport { get; set; }
        [Display(Name = "ToAirport", ResourceType = typeof(Resource_EN))]
        public string ToAirport { get; set; }
        [Display(Name = "FromDate", ResourceType = typeof(Resource_EN))]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "ToDate", ResourceType = typeof(Resource_EN))]
        public DateTime ArrivalDate { get; set; }
    }
}