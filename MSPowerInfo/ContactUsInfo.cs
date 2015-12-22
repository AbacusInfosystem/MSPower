using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace MSPowerInfo
{
    public class ContactUsInfo
    {

        public int ContactUs_Id { get; set; }

        public string ContactUs_Title { get; set; }

        [AllowHtml]


        public string ContactUs_Address { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

    }
    
}