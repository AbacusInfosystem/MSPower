using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;
using CaptchaMvc;


namespace MSPowerWebApp.Models
{
    public class EnquiryViewModel
    {

        public EnquiryInfo Enquiry { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<EnquiryInfo> Enquirys { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Enquiry_Filter Filter { get; set; }

        public EnquiryViewModel()
        
        {
            Enquiry = new EnquiryInfo();

            Pager = new PaginationInfo();

            Enquirys = new List<EnquiryInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }
    }

    public class Enquiry_Filter
    
    {
        public int Enquiry_Id { get; set; }
 
    }
}