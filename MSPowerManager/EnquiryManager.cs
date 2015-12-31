using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class EnquiryManager
    {

        public EnquiryRepo _eRepo = null;

        public EnquiryManager()
        {
            _eRepo = new EnquiryRepo();
        }

        public List<EnquiryInfo> Get_Enquirys(ref PaginationInfo pager, int language_Id)
        {
            return _eRepo.Get_Enquirys(ref pager, language_Id);
        }

        public EnquiryInfo Get_Enquiry_By_Id(int enquiry_Id, int language_Id)
        {
            return _eRepo.Get_Enquiry_By_Id(enquiry_Id, language_Id);
        }

        public int Insert_Enquiry(EnquiryInfo enquiry)
        {
            return _eRepo.Insert_Enquiry(enquiry);
        }

    }
}
