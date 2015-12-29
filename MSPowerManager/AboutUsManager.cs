using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class AboutUsManager
    {

        public AboutUsRepo _auRepo = null;

        public AboutUsManager()
        {
            _auRepo = new AboutUsRepo();
        }

        public List<AboutUsInfo> Get_AboutUss(ref PaginationInfo Pager)
        {
            return _auRepo.Get_AboutUss(ref Pager);
        }

        public AboutUsInfo Get_AboutUs_By_Id(int aboutus_Id)
        {
            return _auRepo.Get_AboutUs_By_Id(aboutus_Id);
        }

        public int Insert_AboutUs(AboutUsInfo aboutus)
        {
            return _auRepo.Insert_AboutUs(aboutus);
        }

        public void Update_AboutUs(AboutUsInfo aboutus)
        {
            _auRepo.Update_AboutUs(aboutus);
        }

    }
}
