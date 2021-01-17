namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviseTimeTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "AirlineID", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "FromAirportID", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "ToAirportID", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "Duration", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.TimeTables", "Stops", c => c.Int(nullable: false));
            AddColumn("dbo.TimeTables", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.TimeTables", "ScheduleID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeTables", "ScheduleID", c => c.Int(nullable: false));
            DropColumn("dbo.TimeTables", "Amount");
            DropColumn("dbo.TimeTables", "Stops");
            DropColumn("dbo.TimeTables", "Duration");
            DropColumn("dbo.TimeTables", "ToAirportID");
            DropColumn("dbo.TimeTables", "FromAirportID");
            DropColumn("dbo.TimeTables", "AirlineID");
        }
    }
}
