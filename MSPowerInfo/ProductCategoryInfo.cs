using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerInfo
{
    public class ProductCategoryInfo
    {

        public ProductCategoryInfo()
        {
            Product_Category_Column_Mappings = new List<ProductCategoryColumnMappingInfo>();
        }

        public int Product_Category_Id { get; set; }

        public int Language_Id { get; set; }

        public string Product_Category1 { get; set; }

        public string Product_Category2 { get; set; }

        public string Product_Category3 { get; set; }

        public string Product_Category_Image { get; set; }

        public string Product_Category_Description { get; set; }

        public List<ProductCategoryColumnMappingInfo> Product_Category_Column_Mappings { get; set; }

    }
}
