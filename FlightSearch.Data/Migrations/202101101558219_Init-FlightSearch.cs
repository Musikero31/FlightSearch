namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitFlightSearch : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airline",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AirlineName = c.String(maxLength: 100, unicode: false),
                        CarrierCode = c.String(maxLength: 5, unicode: false),
                        LogoUrl = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false, defaultValue: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 5, unicode: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        IsActive = c.Boolean(nullable: false, defaultValue: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TimeTables",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FlightDate = c.DateTime(nullable: false, storeType: "date"),
                        DepartureDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        FromAirportID = c.Int(nullable: false),
                        ToAirportID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false, defaultValue: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TimeTables");
            DropTable("dbo.Airports");
            DropTable("dbo.Airline");
        }
    }
}
