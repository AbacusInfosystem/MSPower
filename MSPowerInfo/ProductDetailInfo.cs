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

        public int Product_Detail_Id { get; set; }

        public int Product_Category_Column_Mapping_Id { get; set; }

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

        public string Semikron { get; set; }

        public string Vishay { get; set; }

        public string IR { get; set; }

        public string Hirect { get; set; }

        public string Infenion { get; set; }

        public string Powrex { get; set; }

        public string IXYS_Westcode { get; set; }

        public string Ansaldo { get; set; }

        public string Dynex { get; set; }

        public string Usha { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }
        
        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

        public bool Is_PDF_Exists { get; set; }
    
    }
}
