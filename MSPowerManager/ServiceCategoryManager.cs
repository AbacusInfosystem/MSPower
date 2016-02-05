using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class ServiceCategoryManager
    {

        public ServiceCategoryRepo _scRepo = null;

        public ServiceCategoryManager()
        {
            _scRepo = new ServiceCategoryRepo();
        }

        public List<ServiceCategoryInfo> Get_Services_Categories(ref PaginationInfo pager, int language_Id)
        {
            return _scRepo.Get_Services_Categories(ref pager, language_Id);
        }

        public ServiceCategoryInfo Get_Service_Category_By_Id(int Service_Category_Id, int language_Id)
        {
            return _scRepo.Get_Service_Category_By_Id(Service_Category_Id, language_Id);
        }

        public int Insert_Service_Category(ServiceCategoryInfo ServiceCategory)
        {
            return _scRepo.Insert_Service_Category(ServiceCategory);
        }

        public void Update_Service_Categories(ServiceCategoryInfo ServiceCategory)
        {
            _scRepo.Update_Service_Categories(ServiceCategory);
        }


        // front End


        public List<ServiceCategoryInfo> Get_Service_Categories_By_Language_Id(int language_Id)
        {
            return _scRepo.Get_Service_Categories_By_Language_Id(language_Id);
        }

        public ServiceCategoryInfo Get_Services_Categories_By_Id(int Service_Category_Id, int language_Id)
        {
            return _scRepo.Get_Services_Categories_By_Id(Service_Category_Id, language_Id);
        }

    }
}
