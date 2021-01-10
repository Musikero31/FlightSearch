using FlightSearch.Data.EF.Entities;
using System.Data.Entity;
using FlightSearch.Data.Migrations;

namespace FlightSearch.Data.EF
{
    public class FlightSearchContext : DbContext
    {
        public FlightSearchContext() : base("name=FlightSearchDB")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FlightSearchContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FlightSearchContext, Configuration>());
        }

        public DbSet<Airlines> Airlines { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<TimeTables> TimeTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airlines>()
                .Property(e => e.AirlineName)
                .IsUnicode(false);

            modelBuilder.Entity<Airlines>()
                .Property(e => e.CarrierCode)
                .IsUnicode(false);

            modelBuilder.Entity<Airlines>()
                .Property(e => e.LogoUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Airports>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Airports>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
