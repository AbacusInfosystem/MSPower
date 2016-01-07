using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using MSPowerRepo;

namespace MSPowerManager
{
    public class ProductManager
    {
         public ProductRepo _pRepo = null;

        public ProductManager()
        {
            _pRepo = new ProductRepo();
        }

        public List<ProductInfo> Get_Products(ref PaginationInfo Pager, int language_Id)
        {
            return _pRepo.Get_Products(ref Pager, language_Id);
        }

        public ProductInfo Get_Product_By_Id(int product_Id, int language_Id)
        {
            return _pRepo.Get_Product_By_Id(product_Id, language_Id);
        }

        public int Insert_Product(ProductInfo product)
        {
            return _pRepo.Insert_Product(product);
        }

        public void Update_Product(ProductInfo product)
        {
            _pRepo.Update_Product(product);
        }

        //public List<LookUpInfo> Get_Product_Categories(int language_Id)
        //{

        //    return _pRepo.Get_Product_Categories(language_Id);
        //}
    }
}
