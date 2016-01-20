using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MSPowerInfo
{
    public class ServiceCategoryInfo
    {

        public int Service_Category_Id { get; set; }

        public int Language_Id { get; set; }

        public string Service_Category { get; set; }

        public string Service_Category_Img { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [AllowHtml]

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

    }
}
