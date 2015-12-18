using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;


namespace MSPowerWebApp.Models
{
    public class ProductViewModel
    {
        public ProductInfo Product { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<ProductInfo> Products { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Product_Filter Filter { get; set; }

        public ProductViewModel()
        {
            Product = new ProductInfo();

            Pager = new PaginationInfo();

            Products = new List<ProductInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }
    }

    public class Product_Filter
    {
        public int Product_Id { get; set; }
    }
}