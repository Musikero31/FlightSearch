namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeToFlightDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "FlightDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.TimeTables", "DepartureDate");
            DropColumn("dbo.TimeTables", "ArrivalDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeTables", "ArrivalDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.TimeTables", "DepartureDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.TimeTables", "FlightDate");
        }
    }
}
