namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnAirlineSchedueSTOPSAMOUNT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AirlineSchedules", "Stops", c => c.Int(nullable: false));
            AddColumn("dbo.AirlineSchedules", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AirlineSchedules", "Amount");
            DropColumn("dbo.AirlineSchedules", "Stops");
        }
    }
}
