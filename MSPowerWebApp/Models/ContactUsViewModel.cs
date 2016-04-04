using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;

namespace MSPowerWebApp.Models
{
    public class ContactUsViewModel
    {

        public ContactUsInfo ContactUs { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<ContactUsInfo> ContactUss { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public ContactUs_Filter Filter { get; set; }

        public ContactUsViewModel()
        {

            ContactUs = new ContactUsInfo();

            Pager = new PaginationInfo();

            ContactUss = new List<ContactUsInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

        }
    }

    public class ContactUs_Filter
    {
        public int ContactUs_Id { get; set; }
    }

    
}