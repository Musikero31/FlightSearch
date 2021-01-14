namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviseTimeTableColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "ScheduleID", c => c.Int(nullable: false));
            DropColumn("dbo.TimeTables", "AirlineID");
            DropColumn("dbo.TimeTables", "FlightDate");
            DropColumn("dbo.TimeTables", "FromAirportID");
            DropColumn("dbo.TimeTables", "ToAirportID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeTables", "ToAirportID", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "FromAirportID", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "FlightDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.TimeTables", "AirlineID", c => c.Int(nullable: false));
            DropColumn("dbo.TimeTables", "ScheduleID");
        }
    }
}
