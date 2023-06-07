using FlightSearch.Business.Entities;
using FlightSearch.Business.Utilities;
using FlightSearch.Data.DataAccess.UnitOfWork;
using FlightSearch.Data.EF.Entities;
using NLog;
using System.Collections.Generic;
using System.Linq;

namespace FlightSearch.Business.Components.Maintenance
{
    public class AirlineComponent
    {
        private static readonly Logger _log = LogManager.GetLogger("DebugLoggerRules");
        private const string DEFAULT_LOGO_URL = "https://cdn.shopify.com/s/files/1/0625/8691/3005/products/Pikachu-Knocked-Gloss_01_Top-View_800x.png";
        private AirlineWork _airlineWork = new AirlineWork();

        public void CreateNewArline(AirlineEntity airline)
        {
            Airlines data = GenericHelper.BusinessMapper.Map<Airlines>(airline);
            data.IsActive = true;

            CheckLogoUrl(airline.LogoUrl, data);

            _airlineWork.AirlineRepo.Insert(data);
            _airlineWork.Save();

            _log.Info("New airline created");
        }

        private void CheckLogoUrl(string logoUrl, Airlines data)
        {
            if (string.IsNullOrEmpty(logoUrl))
            {
                data.LogoUrl = DEFAULT_LOGO_URL;
            }
        }

        public void UpdateAirline(AirlineEntity airline)
        {
            var data = _airlineWork.AirlineRepo.GetByID(airline.ID);

            GenericHelper.BusinessMapper.Map(airline, data);
            
            CheckLogoUrl(airline.LogoUrl, data);

            _airlineWork.AirlineRepo.Update(data);

            _airlineWork.Save();

            _log.Info($"Updated airline ID {data.ID}");
        }

        public void DeleteAirline(int id, bool isFullDelete = false)
        {
            if (isFullDelete)
            {
                _airlineWork.AirlineRepo.DeleteByID(id);
            }
            else
            {
                var data = _airlineWork.AirlineRepo.GetByID(id);
                data.IsActive = false;
                _airlineWork.AirlineRepo.Update(data);
            }

            _airlineWork.Save();

            _log.Info($"Deleted airline ID {id}");
        }

        public AirlineEntity GetAirlineById(int id) 
        {
            var result = _airlineWork.AirlineRepo.GetByID(id);

            return GenericHelper.BusinessMapper.Map<AirlineEntity>(result);
        }

        public List<AirlineEntity> Get()
        {
            var result = _airlineWork.AirlineRepo.Get(air => air.IsActive);

            return result
                .Select(air => GenericHelper.BusinessMapper.Map<AirlineEntity>(air))
                .ToList();
        }
    }
}
