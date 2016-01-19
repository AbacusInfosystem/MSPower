﻿using System;
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

        public List<ProductDetailInfo> Get_Product_Details(ref PaginationInfo pager, int product_category_column_mapping_Id, int product_column_ref_Id)
        {
            return _pdRepo.Get_Product_Details(ref pager, product_category_column_mapping_Id, product_column_ref_Id);
        }

        public List<ProductDetailHeaderInfo> Get_Product_Details_Header(int product_column_ref_Id)
        {
            return _pdRepo.Get_Product_Details_Header(product_column_ref_Id);
        }

        public ProductDetailInfo Get_Product_Detail_By_Id(int product_detail_Id, int product_column_ref_Id)
        {
            return _pdRepo.Get_Product_Detail_By_Id(product_detail_Id, product_column_ref_Id);
        }

        public int Insert_Product_Detail(ProductDetailInfo productcolumn)
        {
             return _pdRepo.Insert_Product_Detail(productcolumn);
        }

        public void Update_Product_Detail(ProductDetailInfo productcolumn)
        {
            _pdRepo.Update_Product_Detail(productcolumn);
        }

        public List<ProductCategoryInfo> Get_Product_Categories_By_Lanugae_Id(int language_Id)
        {
            return _pdRepo.Get_Product_Categories_By_Lanugae_Id(language_Id);
        }

        public ProductCategoryColumnMappingInfo Get_Product_Category_Column_By_Id(int product_Category_Column_Id)
        {
            return _pdRepo.Get_Product_Category_Column_By_Id(product_Category_Column_Id);
        }

        public ProductCategoryInfo Get_Product_Category_By_Id(int product_Category_Id, int language_Id)
        {
            return _pdRepo.Get_Product_Category_By_Id(product_Category_Id, language_Id);
        }

    }
}
