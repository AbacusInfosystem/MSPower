using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;

namespace MSPowerWebApp.Models
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {

            Product_Categories = new List<ProductCategoryInfo>();

            Volts = new List<ProductCategoryColumnMappingInfo>();

            Product_Details = new List<ProductDetailInfo>();

            Product_Details_Header = new List<ProductDetailHeaderInfo>();

            Pager = new PaginationInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Columns = new List<ProductColumnInfo>();

            Product_Detail = new ProductDetailInfo();

            Filter = new Product_Detail_Filter();
        }


            // Search Page

            public List<ProductCategoryInfo> Product_Categories { get; set; }

            public List<ProductCategoryColumnMappingInfo> Volts { get; set; }

            public List<ProductDetailHeaderInfo> Product_Details_Header { get; set; }

            public List<ProductDetailInfo> Product_Details { get; set; }

            public PaginationInfo Pager { get; set; }

            public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        
            // Index Page

            public List<ProductColumnInfo> Columns { get; set; }

            public ProductDetailInfo Product_Detail { get; set; }

            public Product_Detail_Filter Filter {get; set;}

    }

            public class Product_Detail_Filter
        {

            public int Product_Category_Id { get; set; }

            public int Product_Category_Column_Mapping_Id { get; set; }

            public int Product_Detail_Id { get; set; }

            public int Product_Column_Ref_Id { get; set; }

    }
}