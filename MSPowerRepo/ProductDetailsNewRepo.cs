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

            _con.Close();

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

            _con.Close();

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

            retval.Semikron = Convert.ToString(dr["Semikron"]);

            retval.Vishay = Convert.ToString(dr["Vishay"]);

            retval.IR = Convert.ToString(dr["IR"]);

            retval.Hirect = Convert.ToString(dr["Hirect"]);

            retval.Infenion = Convert.ToString(dr["Infenion"]);

            retval.Powrex = Convert.ToString(dr["Powrex"]);

            retval.IXYS_Westcode = Convert.ToString(dr["IXYS_Westcode"]);

            retval.Ansaldo = Convert.ToString(dr["Ansaldo"]);

            retval.Dynex = Convert.ToString(dr["Dynex"]);

            retval.Usha = Convert.ToString(dr["Usha"]);

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

            _con.Close();

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

            param.Add(new SqlParameter("@Semikron", productDetail.Semikron));

            param.Add(new SqlParameter("@Vishay", productDetail.Vishay));

            param.Add(new SqlParameter("@IR", productDetail.IR));

            param.Add(new SqlParameter("@Hirect", productDetail.Hirect));

            param.Add(new SqlParameter("@Infenion", productDetail.Infenion));

            param.Add(new SqlParameter("@Powrex", productDetail.Powrex));

            param.Add(new SqlParameter("@IXYS_Westcode", productDetail.IXYS_Westcode));

            param.Add(new SqlParameter("@Ansaldo", productDetail.Ansaldo));

            param.Add(new SqlParameter("@Dynex", productDetail.Dynex));

            param.Add(new SqlParameter("@Usha", productDetail.Usha));

            param.Add(new SqlParameter("@Is_Active", productDetail.Is_Active));

            return param;

        }

        public List<ProductCategoryInfo> Get_Product_Categories_By_Lanugae_Id(int language_Id)
        {
            List<ProductCategoryInfo> product_Categories = new List<ProductCategoryInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.sp_Get_Product_Categories_By_Lanugae_Id.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    ProductCategoryInfo retVal = new ProductCategoryInfo();

                    retVal.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);

                    retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

                    retVal.Product_Category1 = Convert.ToString(dr["Product_Category"]);

                    retVal.Product_Category_Image = Convert.ToString(dr["Product_Category_Img"]);

                    retVal.Product_Category_Description = Convert.ToString(dr["Product_Category_Description"]);

                    retVal.Product_Category_Column_Mappings = Get_Product_Category_Column_By_Category_Id(retVal.Product_Category_Id);

                    product_Categories.Add(retVal);

                }
            }

            return product_Categories;
        }

        public List<ProductCategoryColumnMappingInfo> Get_Product_Category_Column_By_Category_Id(int product_Category_Id)
        {
            List<ProductCategoryColumnMappingInfo> product_Category_Column_Mappings = new List<ProductCategoryColumnMappingInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Category_Id", product_Category_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.sp_Get_Product_Category_Column_By_Category_Id.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ProductCategoryColumnMappingInfo retval = new ProductCategoryColumnMappingInfo();

                    retval.Product_Category_Column_Mapping_Id = Convert.ToInt32(dr["Product_Category_Column_Mapping_Id"]);

                    retval.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);

                    retval.Volts = Convert.ToInt32(dr["Volts"]);

                    retval.Product_Column_Ref_Id = Convert.ToInt32(dr["Product_Column_Ref_Id"]);

                    product_Category_Column_Mappings.Add(retval);

                }
            }

            return product_Category_Column_Mappings;
        }

        public string Genrate_Html_For_Product_Categories(List<ProductCategoryInfo> product_Categories, int parent_Category_Id, int language_Id)
        {
            string html = "";

            html += "<div class='row'>";

            foreach (var item in product_Categories.Where(a => a.Parent_Category_Id == parent_Category_Id))
            {
                html += "<div class='col-md-4'>";

                html += "<ul>";

                html += "<li class='prod-li'>";

                if (language_Id == 1)
                {
                    html += "<h4><a href='/en/product-listing?product_Category_Id=" + item.Product_Category_Id + "'><i class='fa fa-chevron-right'></i>&nbsp;&nbsp;&nbsp;";
                }
                else
                {
                    html += "<h4><a href='/ch/product-listing?product_Category_Id=" + item.Product_Category_Id + "'><i class='fa fa-chevron-right'></i>&nbsp;&nbsp;&nbsp;";
                }

                html += item.Product_Category;

                html += "</a></h4>";

                html += "<ul>";

                foreach (var itm in product_Categories.Where(x => x.Parent_Category_Id == item.Product_Category_Id))
                {
                    if (language_Id == 1)
                    {
                        html += "<li class='prod-li'> <a href='/en/product-listing?product_Category_Id=" + itm.Product_Category_Id + "'><i class='fa fa-chevron-right'></i>&nbsp;&nbsp;&nbsp;";
                    }
                    else
                    {
                        html += "<li class='prod-li'> <a href='/ch/product-listing?product_Category_Id=" + itm.Product_Category_Id + "'><i class='fa fa-chevron-right'></i>&nbsp;&nbsp;&nbsp;";
                    }

                    html += itm.Product_Category;

                    html += "</a></li>";
                }

                html += "</ul>";

                html += "</li>";

                html += "</ul>";

                html += "</div>";
            }

            html += "</div>";

            return html;
        }

        public ProductCategoryInfo Get_Product_Category_By_Id(int product_Category_Id, int language_Id)
        {
            ProductCategoryInfo product_Category = new ProductCategoryInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@product_Category_Id", product_Category_Id));

            param.Add(new SqlParameter("@language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Category_By_Id_sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    product_Category.Product_Category_Id = Convert.ToInt32(dr["Product_Category_Id"]);

                    product_Category.Language_Id = Convert.ToInt32(dr["Language_Id"]);

                    product_Category.Product_Category = Convert.ToString(dr["Product_Category"]);

                    product_Category.Product_Category_Image = Convert.ToString(dr["Product_Category_Img"]);

                    product_Category.Product_Category_Description = Convert.ToString(dr["Product_Category_Description"]);

                }
            }

            return product_Category;
        }

        public ProductCategoryColumnMappingInfo Get_Product_Detail_By_Name(string Col1)
        {
            ProductCategoryColumnMappingInfo volts = new ProductCategoryColumnMappingInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Col1", Col1));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Name_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    volts = Get_Product_Volt_Values(dr);

                    _con.Open();

                    // Product Detail Headers

                    param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@Product_Column_Ref_Id", volts.Product_Column_Ref_Id));

                    DataTable dt1 = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Headers_Sp.ToString(), CommandType.StoredProcedure, _con);

                    _con.Close();

                    int headerCount = 0;

                    if (dt1 != null)
                    {
                        headerCount = dt1.Rows.Count;
                    }

                    volts.Product_Details.Add( Get_Product_Details_Values(dr, headerCount));
                } 
            }

            return volts;
        }

        public ProductCategoryColumnMappingInfo Get_Product_Detail_By_Competitor_Name(string competitor)
        {
            ProductCategoryColumnMappingInfo volts = new ProductCategoryColumnMappingInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Competitor", competitor));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_By_Competitors_Name_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    volts = Get_Product_Volt_Values(dr);

                    _con.Open();

                    // Product Detail Headers

                    param = new List<SqlParameter>();

                    param.Add(new SqlParameter("@Product_Column_Ref_Id", volts.Product_Column_Ref_Id));

                    DataTable dt1 = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Headers_Sp.ToString(), CommandType.StoredProcedure, _con);

                    _con.Close();

                    int headerCount = 0;

                    if (dt1 != null)
                    {
                        headerCount = dt1.Rows.Count;
                    }

                    volts.Product_Details.Add(Get_Product_Details_Values(dr, headerCount));
                }
            }

            return volts;
        }

        public string Genrate_Html_For_Product_Categories_Images(List<ProductCategoryInfo> product_Categories, int parent_Category_Id, int language_Id)
        {
            string html = "";


            int i = 0;

            foreach (var item in product_Categories.Where(a => a.Parent_Category_Id == parent_Category_Id))
            {
                if (!string.IsNullOrEmpty(item.Product_Category_Image))
                {
                    if (i % 3 == 0 || i == 0)
                    {
                        html += "<div class='about-grids service_box'>";
                    }

                    html += "<div class='col-sm-4 about-grid'>";

                    html += "<a href='/en/product-listing?product_Category_Id=" + item.Product_Category_Id + "' title='name' rel='" + item.Product_Category + "'>";

                    html += "<div class='view view-first'>";

                    html += "<img src='/Content/Images/Product%20Categories/" + item.Product_Category_Image.Replace(" ", "%20") + "' class='img-responsive' alt='" + item.Product_Category_Image + "' />";

                    html += "</div>";

                    html += "</a>";

                    // html += "<h3><a href='#'>" + item.Product_Category + "</a></h3>";

                    if (language_Id == 1)
                    {
                        html += "<h3> <a href='/en/product-listing?product_Category_Id=" + item.Product_Category_Id + "'>" + item.Product_Category + "</h3>";
                    }
                    else
                    {
                        html += "<h3> <a href='/ch/product-listing?product_Category_Id=" + item.Product_Category_Id + "'>" + item.Product_Category + "</h3>";
                    }

                    html += "</div>";

                    i++;

                    if (i % 3 == 0 )
                    {
                        html += "<div class='clearfix'> </div>";

                        html += "</div>";
                    }

                    foreach (var itm in product_Categories.Where(x => x.Parent_Category_Id == item.Product_Category_Id))
                    {
                        if (i % 3 == 0 || i == 0)
                        {
                            html += "<div class='about-grids service_box'>";
                        }

                        html += "<div class='col-sm-4 about-grid'>";

                        html += "<a href='/en/product-listing?product_Category_Id=" + itm.Product_Category_Id + "' title='name' rel='" + itm.Product_Category + "'>";

                        html += "<div class='view view-first'>";

                        html += "<img src='/Content/Images/Product%20Categories/" + itm.Product_Category_Image.Replace(" ", "%20") + "' class='img-responsive' alt='" + itm.Product_Category_Image + "' />";

                        html += "</div>";

                        html += "</a>";

                        // html += "<h3><a href='#'>" + item.Product_Category + "</a></h3>";

                        if (language_Id == 1)
                        {
                            html += "<h3> <a href='/en/product-listing?product_Category_Id=" + itm.Product_Category_Id + "'>" + itm.Product_Category + "</h3>";
                        }
                        else
                        {
                            html += "<h3> <a href='/ch/product-listing?product_Category_Id=" + itm.Product_Category_Id + "'>" + itm.Product_Category + "</h3>";
                        }

                        html += "</div>";

                        i++;

                        if (i % 3 == 0)
                        {
                            html += "<div class='clearfix'> </div>";

                            html += "</div>";
                        }
                    }
                }
            }

          

            return html;
        }

        public List<ProductDetailInfo> Get_Product_Details_By_Col(ref PaginationInfo pager, int product_category_column_mapping_Id, int product_column_ref_Id, Product_Details_Col_Filter col_Filter)
        {
            List<ProductDetailInfo> productDetails = new List<ProductDetailInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            // Product Detail Headers

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Column_Ref_Id", product_column_ref_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_Headers_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            int headerCount = 0;

            if (dt != null)
            {
                headerCount = dt.Rows.Count;
            }

            // Product Detail Values

            param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Category_Column_Mapping_Id", product_category_column_mapping_Id));

            param.Add(new SqlParameter("@Col1", string.IsNullOrEmpty(col_Filter.Col1) || col_Filter.Col1 == "null" ? ""  : col_Filter.Col1));

            string abc = string.IsNullOrEmpty(col_Filter.Col2) || col_Filter.Col2 =="null" ? "" : col_Filter.Col2;

            param.Add(new SqlParameter("@Col2", string.IsNullOrEmpty(col_Filter.Col2)|| col_Filter.Col2 =="null" ? "" : col_Filter.Col2));

            param.Add(new SqlParameter("@Col3", string.IsNullOrEmpty(col_Filter.Col3) || col_Filter.Col3 == "null" ? "" : col_Filter.Col3));

            param.Add(new SqlParameter("@Col4", string.IsNullOrEmpty(col_Filter.Col4) || col_Filter.Col4 == "null" ? "" : col_Filter.Col4));

            param.Add(new SqlParameter("@Col5", string.IsNullOrEmpty(col_Filter.Col5) || col_Filter.Col5 == "null" ? "" : col_Filter.Col5));

            param.Add(new SqlParameter("@Col6", string.IsNullOrEmpty(col_Filter.Col6) || col_Filter.Col6 == "null" ? "" : col_Filter.Col6));

            param.Add(new SqlParameter("@Col7", string.IsNullOrEmpty(col_Filter.Col7) || col_Filter.Col7 == "null" ? "" : col_Filter.Col7));

            param.Add(new SqlParameter("@Col8", string.IsNullOrEmpty(col_Filter.Col8) || col_Filter.Col8 == "null" ? "" : col_Filter.Col8));

            param.Add(new SqlParameter("@Col9", string.IsNullOrEmpty(col_Filter.Col9) || col_Filter.Col9 == "null" ? "" : col_Filter.Col9));

            param.Add(new SqlParameter("@Col10", string.IsNullOrEmpty(col_Filter.Col10) || col_Filter.Col10 == "null" ? "" : col_Filter.Col10));

            param.Add(new SqlParameter("@Col11", string.IsNullOrEmpty(col_Filter.Col11) || col_Filter.Col11 == "null" ? "" : col_Filter.Col11));

            param.Add(new SqlParameter("@Col12", string.IsNullOrEmpty(col_Filter.Col12) || col_Filter.Col12 == "null" ? "" : col_Filter.Col12));

            param.Add(new SqlParameter("@Col13", string.IsNullOrEmpty(col_Filter.Col13) || col_Filter.Col13 == "null" ? "" : col_Filter.Col13));

            param.Add(new SqlParameter("@Col14", string.IsNullOrEmpty(col_Filter.Col14) || col_Filter.Col14 == "null" ? "" : col_Filter.Col14));

            param.Add(new SqlParameter("@Col15", string.IsNullOrEmpty(col_Filter.Col15) || col_Filter.Col15 == "null" ? "" : col_Filter.Col15));

            dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Details_By_Col.ToString(), CommandType.StoredProcedure, _con);

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
    }
}
