namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsAirlineSchedule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AirlineSchedules", "FromAirportID", c => c.Int(nullable: false));
            AddColumn("dbo.AirlineSchedules", "ToAirportID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AirlineSchedules", "ToAirportID");
            DropColumn("dbo.AirlineSchedules", "FromAirportID");
        }
    }
}
