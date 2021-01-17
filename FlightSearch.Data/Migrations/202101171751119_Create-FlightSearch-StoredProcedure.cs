namespace FlightSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFlightSearchStoredProcedure : DbMigration
    {
        public override void Up()
        {
			CreateStoredProcedure(
				"dbo.SearchFlights",
				sp => new 
				{
					FromDate = sp.DateTime(),
					ToDate = sp.DateTime(),
					FromAirport = sp.String(),
					ToAirport = sp.String()
				},
				body: @"IF OBJECT_ID('tempdb..#SearchResults') IS NOT NULL
			BEGIN
				DROP TABLE #SearchResults
			END

			CREATE TABLE #SearchResults (
				ID INT NOT NULL identity(1, 1)
				,FlightDate DATE
				,CarrierCode VARCHAR(10)
				,AirlineLogo VARCHAR(max)
				,AirlineName VARCHAR(100)
				,InboundFlight VARCHAR(100)
				,InboundFlightDuration TIME(7)
				,OutboundFlight VARCHAR(100)
				,OutboundFlightDuration TIME(7)
				,Stops INT
				,Amount DECIMAL(18, 2)
				)

			INSERT INTO #SearchResults (
				FlightDate
				,AirlineLogo
				,CarrierCode
				,AirlineName
				,InboundFlightDuration
				,InboundFlight
				,Stops
				,Amount
				)
			SELECT tt.FlightDate
				,air.LogoUrl
				,air.CarrierCode
				,air.AirlineName
				,tt.Duration
				,src.Name + ' -> ' + dest.Name
				,tt.Stops
				,tt.Amount
			FROM TimeTables AS tt
			INNER JOIN Airports AS src ON tt.FromAirportID = src.ID
			INNER JOIN Airports AS dest ON tt.ToAirportID = dest.ID
			INNER JOIN Airlines AS air ON tt.AirlineID = air.ID
			WHERE tt.FlightDate >= @FromDate
				AND tt.FlightDate <= @ToDate
				AND src.Code = @FromAirport
				AND dest.Code = @ToAirport

			UPDATE #SearchResults
			SET OutboundFlight = src.Name + ' -> ' + dest.Name
				,OutboundFlightDuration = tt.Duration
			FROM TimeTables AS tt
			INNER JOIN Airports AS src ON tt.FromAirportID = src.ID
			INNER JOIN Airports AS dest ON tt.ToAirportID = dest.ID
			INNER JOIN Airlines AS air ON tt.AirlineID = air.ID
			WHERE tt.FlightDate >= @FromDate
				AND tt.FlightDate <= @ToDate
				AND src.Code = @ToAirport
				AND dest.Code = @FromAirport

			SELECT *
			FROM #SearchResults
				");
            
        }
        
        public override void Down()
        {
			DropStoredProcedure("dbo.SearchFlights");
		}
    }
}
