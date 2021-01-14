namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAirlineToTimeTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeTables", "AirlineID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TimeTables", "AirlineID");
        }
    }
}
