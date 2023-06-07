using FlightSearch.Data.EF;
using FlightSearch.Data.EF.Entities;
using FlightSearch.Data.Repository;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Data.DataAccess.UnitOfWork
{
    public class AirlineWork
    {
        private readonly FlightSearchContext _context = new FlightSearchContext();
		private readonly FlightRepository<Airlines> _airlineRepo;
        private bool _isDisposed = false;

        public FlightRepository<Airlines> AirlineRepo 
        { 
            get
            {
                return _airlineRepo ?? new FlightRepository<Airlines>(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (!_isDisposed) 
            {
                if(disposing) 
                {
                    _context.Dispose();
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
