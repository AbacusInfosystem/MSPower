using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MSPowerInfo
{
    public class Job_OpeningInfo
    {

        public Job_OpeningInfo()
        
          {
          
          }


        public int Job_Opening_Id { get; set; }

        public string Job_Title { get; set; }

        [AllowHtml]

        public string Job_Description { get; set; }

        public string CTC { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }


    }
}
