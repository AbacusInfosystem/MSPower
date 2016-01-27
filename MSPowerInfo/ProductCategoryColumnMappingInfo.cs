using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerInfo
{
    public class ProductCategoryColumnMappingInfo
    {

        public ProductCategoryColumnMappingInfo()
        {
            Product_Details_Header = new List<ProductDetailHeaderInfo>();

            Product_Details = new List<ProductDetailInfo>();
        }

        public int Product_Category_Id { get; set; }

        public int Product_Category_Column_Mapping_Id { get; set; }

        public int Volts { get; set; }

        public int Product_Column_Ref_Id { get; set; }

        public List<ProductDetailHeaderInfo> Product_Details_Header { get; set; }

        public List<ProductDetailInfo> Product_Details { get; set; }
    }
}
