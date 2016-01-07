using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSPowerInfo;
using DataAccess.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace MSPowerRepo
{
    public class ProductRepo
    {
        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public ProductRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<ProductInfo> Get_Products(ref PaginationInfo pager, int language_Id)
        {
            List<ProductInfo> products = new List<ProductInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Products_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    products.Add(Get_Product_Values(dr));
                }
            }

            return products;
        }

        public ProductInfo Get_Product_By_Id(int product_Id, int language_Id)
        {
            ProductInfo product = new ProductInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Id", product_Id));

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    product = Get_Product_Values(dr);
                }
            }

            return product;
        }

        public int Insert_Product(ProductInfo product)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Product_Values(product);

            int product_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Product_Sp.ToString(), CommandType.StoredProcedure, _con));

            return product_Id;
        }

        public void Update_Product(ProductInfo product)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Product_Values(product);

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Product_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public ProductInfo Get_Product_Values(DataRow dr)
       
        {
            ProductInfo retVal = new ProductInfo();

            retVal.Product_Id = Convert.ToInt32(dr["Product_Id"]);

            retVal.Product_Title = Convert.ToString(dr["Product_Title"]);

            retVal.Product_Description = Convert.ToString(dr["Product_Description"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_Product_Values(ProductInfo product)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Title", product.Product_Title));

            param.Add(new SqlParameter("@Product_Description", product.Product_Description));

            param.Add(new SqlParameter("@Language_Id", product.Language_Id));

            param.Add(new SqlParameter("@Is_Active", product.Is_Active));

            param.Add(new SqlParameter("@Updated_On", product.Updated_On));

            param.Add(new SqlParameter("@Updated_By", product.Updated_By));

            if (product.Product_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", product.Created_On));

                param.Add(new SqlParameter("@Created_By", product.Created_By));
            }

            if (product.Product_Id != 0)
            {
                param.Add(new SqlParameter("@Product_Id", product.Product_Id));
            }

            return param;
        }

        //public List<LookUpInfo> Get_Product_Categories1(int language_Id)
        //{
        //    List<LookUpInfo> product_categories1 = new List<LookUpInfo>();

        //    SqlDataAccess sqlDataAccess = new SqlDataAccess();

        //    SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

        //    _con.Open();

        //    List<SqlParameter> param = new List<SqlParameter>();

        //    param.Add(new SqlParameter("@Language_Id", language_Id));

        //    DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Product_Categories1_Sp.ToString(), CommandType.StoredProcedure, _con);

        //    _con.Close();

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            LookUpInfo product_category = new LookUpInfo();

        //            product_category.Id = Convert.ToInt32(dr["Product_Category_Id"]);

        //            product_category.Value = Convert.ToString(dr["Product_Category1_EN"]);

        //            product_categories1.Add(product_category);
        //        }
        //    }

        //    return product_categories1;
        //}

    }
}






















          