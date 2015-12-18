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

        public List<ProductInfo> Get_Products(ref PaginationInfo Pager)
        {
            return _pRepo.Get_Products(ref Pager);
        }

        public ProductInfo Get_Product_By_Id(int product_Id)
        {
            return _pRepo.Get_Product_By_Id(product_Id);
        }

        public int Insert_Product(ProductInfo product)
        {
            return _pRepo.Insert_Product(product);
        }

        public void Update_Product(ProductInfo product)
        {
            _pRepo.Update_Product(product);
        }
    }
}
