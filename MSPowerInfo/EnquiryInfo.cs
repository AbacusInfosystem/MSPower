using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MSPowerInfo
{
    public class EnquiryInfo
    {

        public EnquiryInfo()
        
          {
          
          }

        public int Enquiry_Id { get; set; }

        public int Language_Id { get; set; }

        [AllowHtml]

        public String Customer_Name { get; set; }

        public String Customer_Address { get; set; }

        public String Tel_No { get; set; }

        public String Email { get; set; }

        public String Contact_Person { get; set; }

        public String Contact_Person_Tel_No { get; set; }

        public String Contact_Person_Mobile_No { get; set; }

        public String Enquiry_No { get; set; }

        public DateTime Enquiry_Date { get; set; }

        public String Product_Name { get; set; }

        public int Quantity { get; set; }

        public String Delivery { get; set; }

        public DateTime Created_On { get; set; }
        
    }
}
