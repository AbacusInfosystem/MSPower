using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MSPowerInfo
{
    public class Job_ApplicationInfo
    {

        public Job_ApplicationInfo()
        
          {
          
          }


        public int Job_Application_Id { get; set; }

        [AllowHtml]

        public String First_Name{ get; set; }

        public String Last_Name { get; set; }

        public String Email { get; set; }

        public String Reference { get; set; }

        public String Additional_Information { get; set; }

        public DateTime Created_On { get; set; }

    }
}
