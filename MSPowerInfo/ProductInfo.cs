using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace MSPowerInfo
{
    public class ProductInfo
    
    {

          public ProductInfo()
        
          {
          
          }


        public int Product_Id { get; set; }

        public int Language_Id { get; set; }

        public string Product_Title { get; set; }

        [AllowHtml]
        public string Product_Description { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

    }
}
