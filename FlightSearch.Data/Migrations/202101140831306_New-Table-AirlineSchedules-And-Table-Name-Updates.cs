namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableAirlineSchedulesAndTableNameUpdates : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Airline", newName: "Airlines");
            CreateTable(
                "dbo.AirlineSchedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AirlineID = c.Int(nullable: false),
                        Frequency = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AirlineSchedules");
            RenameTable(name: "dbo.Airlines", newName: "Airline");
        }
    }
}
