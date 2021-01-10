using FlightSearch.Data.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Data.EF
{
    public class FlightSearchContext : DbContext
    {
        public FlightSearchContext() : base("name=FlightSearchDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FlightSearchContext>());
        }

        public DbSet<Airlines> Airlines { get; set; }
    }
}
