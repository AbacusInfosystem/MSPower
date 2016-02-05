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

            Col_Filter = new Product_Details_Col_Filter();

            Col_Filter.Col1 = "";

            Col_Filter.Col2 = "";

            Col_Filter.Col3 = "";

            Col_Filter.Col4 = "";

            Col_Filter.Col5 = "";

            Col_Filter.Col6 = "";

            Col_Filter.Col7 = "";

            Col_Filter.Col8 = "";

            Col_Filter.Col9 = "";

            Col_Filter.Col10 = "";

            Col_Filter.Col11 = "";

            Col_Filter.Col12 = "";

            Col_Filter.Col13 = "";

            Col_Filter.Col14 = "";

            Col_Filter.Col15 = "";
        }

        public int Product_Category_Id { get; set; }

        public int Product_Category_Column_Mapping_Id { get; set; }

        public int Volts { get; set; }

        public int Product_Column_Ref_Id { get; set; }

        public List<ProductDetailHeaderInfo> Product_Details_Header { get; set; }

        public List<ProductDetailInfo> Product_Details { get; set; }

        public Product_Details_Col_Filter Col_Filter { get; set; }

    }

    public class Product_Details_Col_Filter
    {
        public string Col1 { get; set; }

        public string Col2 { get; set; }

        public string Col3 { get; set; }

        public string Col4 { get; set; }

        public string Col5 { get; set; }

        public string Col6 { get; set; }

        public string Col7 { get; set; }

        public string Col8 { get; set; }

        public string Col9 { get; set; }

        public string Col10 { get; set; }

        public string Col11 { get; set; }

        public string Col12 { get; set; }

        public string Col13 { get; set; }

        public string Col14 { get; set; }

        public string Col15 { get; set; }
    }
}
