﻿namespace FlightSearch.Business.Entities
{
    public class AirlineEntity
    {
        public int ID { get; set; }
        public string AirlineName { get; set; }
        public string CarrierCode { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
