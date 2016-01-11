using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class ServicesManager
    
    {

        public ServicesRepo _sRepo = null;

        public ServicesManager()
        {
            _sRepo = new ServicesRepo();
        }

        public List<ServicesInfo> Get_Services(ref PaginationInfo pager, int language_Id)
        {
            return _sRepo.Get_Services(ref pager, language_Id);
        }

        public ServicesInfo Get_Services_By_Id(int services_Id, int language_Id)
        {
            return _sRepo.Get_Services_By_Id(services_Id, language_Id);
        }

        public int Insert_Services(ServicesInfo services)
        {
            return _sRepo.Insert_Services(services);
        }

        public void Update_Services(ServicesInfo services)
        {
            _sRepo.Update_Services(services);
        }

        public List<LookUpInfo> Get_Services_Categories(int language_Id)
        {
            return _sRepo.Get_Services_Categories(language_Id);
        }

    }
}