using FlightSearch.Data.EF.Entities;
using System;
using System.Data.Entity.Migrations;

namespace FlightSearch.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EF.FlightSearchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF.FlightSearchContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Airlines.AddOrUpdate(air => air.ID, new Airlines
            {
                ID = 1,
                AirlineName = "Philippine Airlines",
                CarrierCode = "PAL",
                LogoUrl = "https://fontmeme.com/images/Philippine-Airlines-Logo.jpg",
                IsActive = true
            }, new Airlines
            {
                ID = 2,
                AirlineName = "Cebu Pacific Airlines",
                CarrierCode = "CEB",
                LogoUrl = "https://media.giphy.com/avatars/cebupacificair/1W7NUg1dYLYJ.png",
                IsActive = true
            }, new Airlines
            {
                ID = 3,
                AirlineName = "AirAsia",
                CarrierCode = "AXM",
                LogoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f5/AirAsia_New_Logo.svg/1024px-AirAsia_New_Logo.svg.png",
                IsActive = true
            }, new Airlines
            {
                ID = 4,
                AirlineName = "Korean Air",
                CarrierCode = "KAL",
                LogoUrl = "http://s3.amazonaws.com/gt7sp-prod/decal/08/40/55/7070665717768554008_1.png",
                IsActive = true
            });

            context.Airports.AddOrUpdate(ap => ap.ID, new Airports
            {
                ID = 1,
                Code = "MNL",
                Name = "Manila",
                IsActive = true
            }, new Airports
            {
                ID = 2,
                Code = "KUL",
                Name = "Kuala Lumpur",
                IsActive = true
            }, new Airports
            {
                ID = 3,
                Code = "LAX",
                Name = "Los Angeles",
                IsActive = true
            });

            context.AirlineSchedules.AddOrUpdate(asc => asc.ID, new AirlineSchedules
            {
                ID = 1,
                AirlineID = 1,
                FromAirportID = 1,
                ToAirportID = 3,
                Duration = new TimeSpan(12, 40, 0),
                Frequency = "1,2,4,5",
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 2,
                AirlineID = 1,
                FromAirportID = 3,
                ToAirportID = 1,
                Duration = new TimeSpan(15, 20, 0),
                Frequency = "1,2,4,5",
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 3,
                AirlineID = 1,
                FromAirportID = 1,
                ToAirportID = 2,
                Duration = new TimeSpan(3, 50, 0),
                Frequency = "2,4,6",
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 4,
                AirlineID = 1,
                FromAirportID = 2,
                ToAirportID = 1,
                Duration = new TimeSpan(3, 45, 0),
                Frequency = "2,4,6",
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 5,
                AirlineID = 2,
                FromAirportID = 1,
                ToAirportID = 2,
                Frequency = "1,3,5",
                Duration = new TimeSpan(4, 0, 0),
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 6,
                AirlineID = 2,
                FromAirportID = 2,
                ToAirportID = 1,
                Frequency = "1,3,5",
                Duration = new TimeSpan(4, 15, 0),
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 7,
                AirlineID = 3,
                FromAirportID = 1,
                ToAirportID = 2,
                Frequency = "1,3,4",
                Duration = new TimeSpan(4, 5, 0),
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 8,
                AirlineID = 3,
                FromAirportID = 2,
                ToAirportID = 1,
                Frequency = "1,3,4",
                Duration = new TimeSpan(4, 0, 0),
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 9,
                AirlineID = 4,
                FromAirportID = 1,
                ToAirportID = 3,
                Frequency = "5,6,7",
                Duration = new TimeSpan(15, 10, 0),
                IsActive = true
            }, new AirlineSchedules
            {
                ID = 10,
                AirlineID = 4,
                FromAirportID = 3,
                ToAirportID = 1,
                Frequency = "5,6,7",
                Duration = new TimeSpan(17, 40, 0),
                IsActive = true
            });
        }
    }
}
