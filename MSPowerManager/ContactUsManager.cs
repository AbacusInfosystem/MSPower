using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;


namespace MSPowerManager
{
    public class ContactUsManager
    {

        public ContactUsRepo _cuRepo = null;

        public ContactUsManager()
        {
            _cuRepo = new ContactUsRepo();
        }

        public List<ContactUsInfo> Get_ContactUss(ref PaginationInfo Pager)
        {
            return _cuRepo.Get_ContactUss(ref Pager);
        }

        public ContactUsInfo Get_ContactUs_By_Id(int contactus_Id)
        {
            return _cuRepo.Get_ContactUs_By_Id(contactus_Id);
        }

        public int Insert_ContactUs(ContactUsInfo contactus)
        {
            return _cuRepo.Insert_ContactUs(contactus);
        }

        public void Update_ContactUs(ContactUsInfo contactus)
        {
             _cuRepo.Update_ContactUs(contactus);
        }

    }
}
