using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class ProductDetailManager
    {
        public ProductDetailRepo _pdRepo = null;

        public ProductDetailManager()
        {
            _pdRepo = new ProductDetailRepo();
        }

        public List<ProductCategoryInfo> Get_Product_Categories(int language_Id)
        {
            return _pdRepo.Get_Product_Categories(language_Id);
        }

        public List<ProductCategoryColumnMappingInfo> Get_Product_Volts(int product_category_Id)
        {
            return _pdRepo.Get_Product_Volts(product_category_Id);
        }

        public List<ProductDetailInfo> Get_Product_Details(int product_category_column_mapping_Id)
        {
            return _pdRepo.Get_Product_Details(product_category_column_mapping_Id);
        }


    }
}
