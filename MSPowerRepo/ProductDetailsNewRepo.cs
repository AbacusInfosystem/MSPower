using DataAccess.Sql;
using MSPowerInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerRepo
{
    public class ProductDetailsNewRepo
    {
        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public ProductDetailsNewRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<ProductCategoryInfo> Get_Product_Categories_By_Language_Parent(int language_Id, int parent_Product_Category_Id)
        {
            List<ProductCategoryInfo> productcategories = new List<ProductCategoryInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            param.Add(new SqlParameter("@Parent_Category_Id", parent_Product_Category_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Categories_By_Language_Parent_sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    productcategories.Add(Get_Product_Category_Values(dr));
                }
            }

            return productcategories;
        }

        public List<ProductCategoryInfo> Get_Product_Categories_By_Language(int language_Id)
        {
            List<ProductCategoryInfo> productcategories = new List<ProductCategoryInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Categories_By_Lanugae_Id_sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    productcategories.Add(Get_Product_Category_Values(dr));
                }
            }

            return productcategories;
        }

        public ProductCategoryInfo Get_Product_Category_Values(DataRow dr)
        {
            ProductCategoryInfo retVal = new ProductCategoryInfo();

            retVal.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.Parent_Category_Id = Convert.ToInt32(dr["Parent_Category_Id"]);

            retVal.Product_Category = Convert.ToString(dr["Product_Category"]);

            retVal.Product_Category_Description = Convert.ToString(dr["Product_Category_Description"]);

            retVal.Product_Category_Image = Convert.ToString(dr["Product_Category_Img"]);

            return retVal;
        }

        public List<ProductCategoryColumnMappingInfo> Get_Product_Volts(int product_category_Id)
        {
            List<ProductCategoryColumnMappingInfo> volts = new List<ProductCategoryColumnMappingInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Category_Id", product_category_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Volts_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    volts.Add(Get_Product_Volt_Values(dr));
                }
            }

            return volts;
        }

        public ProductCategoryColumnMappingInfo Get_Product_Volt_Values(DataRow dr)
        {

            ProductCategoryColumnMappingInfo retval = new ProductCategoryColumnMappingInfo();

            retval.Product_Category_Column_Mapping_Id = Convert.ToInt32(dr["Product_Category_Column_Mapping_Id"]);

            retval.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);

            retval.Volts = Convert.ToInt32(dr["Volts"]);

            retval.Product_Column_Ref_Id = Convert.ToInt32(dr["Product_Column_Ref_Id"]);

            return retval;

        }

        public List<ProductDetailHeaderInfo> Get_Product_Details_Header(int product_column_ref_Id)
        {
            List<ProductDetailHeaderInfo> productheadercolummns = new List<ProductDetailHeaderInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Column_Ref_Id", product_column_ref_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Headers_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    productheadercolummns.Add(Get_Product_Details_Header_Values(dr));
                }
            }

            //productheadercolummns.Add(new ProductDetailHeaderInfo() { Product_Column_Name = "Status" });

            return productheadercolummns;

        }

        public ProductDetailHeaderInfo Get_Product_Details_Header_Values(DataRow dr)
        {

            ProductDetailHeaderInfo retval = new ProductDetailHeaderInfo();

            retval.Product_Column_Name = Convert.ToString(dr["Product_Column_Name"]);

            return retval;

        }

        public List<ProductDetailInfo> Get_Product_Details(ref PaginationInfo pager, int product_category_column_mapping_Id, int product_column_ref_Id)
        {
            List<ProductDetailInfo> productDetails = new List<ProductDetailInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            // Product Detail Headers

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Column_Ref_Id", product_column_ref_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Headers_Sp.ToString(), CommandType.StoredProcedure, _con);

            int headerCount = 0;

            if (dt != null)
            {
                headerCount = dt.Rows.Count;
            }

            // Product Detail Values

            param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Category_Column_Mapping_Id", product_category_column_mapping_Id));

            dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    productDetails.Add(Get_Product_Details_Values(dr, headerCount));
                }
            }

            return productDetails;
        }

        public ProductDetailInfo Get_Product_Details_Values(DataRow dr, int headerCount)
        {

            ProductDetailInfo retval = new ProductDetailInfo();

            retval.Product_Detail_Id = Convert.ToInt32(dr["Product_Detail_Id"]);

            retval.Product_Category_Column_Mapping_Id = Convert.ToInt32(dr["Product_Category_Column_Mapping_Id"]);

            retval.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            if (headerCount >= 1)
            {
                retval.Col1 = Convert.ToString(dr["Col1"]);
            }
            if (headerCount >= 2)
            {
                retval.Col2 = Convert.ToString(dr["Col2"]);
            }
            if (headerCount >= 3)
            {
                retval.Col3 = Convert.ToString(dr["Col3"]);
            }
            if (headerCount >= 4)
            {
                retval.Col4 = Convert.ToString(dr["Col4"]);
            }
            if (headerCount >= 5)
            {
                retval.Col5 = Convert.ToString(dr["Col5"]);
            }
            if (headerCount >= 6)
            {
                retval.Col6 = Convert.ToString(dr["Col6"]);
            }
            if (headerCount >= 7)
            {
                retval.Col7 = Convert.ToString(dr["Col7"]);
            }
            if (headerCount >= 8)
            {
                retval.Col8 = Convert.ToString(dr["Col8"]);
            }
            if (headerCount >= 9)
            {
                retval.Col9 = Convert.ToString(dr["Col9"]);
            }
            if (headerCount >= 10)
            {
                retval.Col10 = Convert.ToString(dr["Col10"]);
            }
            if (headerCount >= 11)
            {
                retval.Col11 = Convert.ToString(dr["Col11"]);
            }
            if (headerCount >= 12)
            {
                retval.Col12 = Convert.ToString(dr["Col12"]);
            }
            if (headerCount >= 13)
            {
                retval.Col13 = Convert.ToString(dr["Col13"]);
            }
            if (headerCount >= 14)
            {
                retval.Col14 = Convert.ToString(dr["Col14"]);
            }
            if (headerCount >= 15)
            {
                retval.Col15 = Convert.ToString(dr["Col15"]);
            }

            return retval;

        }

        public ProductDetailInfo Get_Product_Detail_By_Id(int product_detail_Id, int product_column_ref_Id)
        {
            ProductDetailInfo productDetail = new ProductDetailInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            // Product Detail Headers

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Column_Ref_Id", product_column_ref_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Headers_Sp.ToString(), CommandType.StoredProcedure, _con);

            int headerCount = 0;

            if (dt != null)
            {
                headerCount = dt.Rows.Count;
            }

            // Product Detail Value

            param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Detail_Id", product_detail_Id));

            dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Detail_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    productDetail = Get_Product_Details_Values(dr, headerCount);
                }
            }

            return productDetail;
        }

        public int Insert_Product_Detail(ProductDetailInfo productcolumn)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Product_Details_Values(productcolumn);

            return Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Product_Detail_Sp.ToString(), CommandType.StoredProcedure, _con));

        }

        public void Update_Product_Detail(ProductDetailInfo productcolumn)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Product_Details_Values(productcolumn);

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Product_Detail_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        private List<SqlParameter> Set_Product_Details_Values(ProductDetailInfo productDetail)
        {

            List<SqlParameter> param = new List<SqlParameter>();

            if (productDetail.Product_Detail_Id > 0)
            {
                param.Add(new SqlParameter("@Product_Detail_Id", productDetail.Product_Detail_Id));
            }

            param.Add(new SqlParameter("@Product_Category_Column_Mapping_Id", productDetail.Product_Category_Column_Mapping_Id));

            param.Add(new SqlParameter("@Col1", productDetail.Col1));

            param.Add(new SqlParameter("@Col2", productDetail.Col2));

            param.Add(new SqlParameter("@Col3", productDetail.Col3));

            param.Add(new SqlParameter("@Col4", productDetail.Col4));

            param.Add(new SqlParameter("@Col5", productDetail.Col5));

            param.Add(new SqlParameter("@Col6", productDetail.Col6));

            param.Add(new SqlParameter("@Col7", productDetail.Col7));

            param.Add(new SqlParameter("@Col8", productDetail.Col8));

            param.Add(new SqlParameter("@Col9", productDetail.Col9));

            param.Add(new SqlParameter("@Col10", productDetail.Col10));

            param.Add(new SqlParameter("@Col11", productDetail.Col11));

            param.Add(new SqlParameter("@Col12", productDetail.Col12));

            param.Add(new SqlParameter("@Col13", productDetail.Col13));

            param.Add(new SqlParameter("@Col14", productDetail.Col14));

            param.Add(new SqlParameter("@Col15", productDetail.Col15));

            param.Add(new SqlParameter("@Is_Active", productDetail.Is_Active));

            return param;

        }

        public string Genrate_Html_For_Product_Categories(List<ProductCategoryInfo> product_Categories, int parent_Category_Id)
        {
            string html = "";

            foreach (var item in product_Categories.Where(a => a.Parent_Category_Id == parent_Category_Id))
            {
                html += "<ul>";

                html += "<li>";

                html += "<h4><a href='#'><i class='fa fa-chevron-right'></i>";

                html += item.Product_Category;

                html += "</a></h4>";

                html += "<ul>";

                foreach (var itm in product_Categories.Where(x => x.Parent_Category_Id == item.Product_Category_Id))
                {

                    html += "<li> <a href='#'><i class='fa fa-chevron-right'></i>";

                    html += itm.Product_Category;

                    html += "</a></li>";
                }

                html += "</ul>";

                html += "</li>";

                html += "</ul>";
            }

            return html;
        }
    }
}
