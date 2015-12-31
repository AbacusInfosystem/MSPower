using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace MSPowerInfo
{
    public class ProductDetailInfo
    {

        public ProductDetailInfo()
        {


        }

        public int Product_Category_Column_Mapping_Id { get; set; }

        public string Col1 { get; set; }

        public string Col2 { get; set; }

        public string Col3 { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }
        
        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }
    
    }
}
