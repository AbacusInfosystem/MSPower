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

        public List<ProductInfo> Get_Products(ref PaginationInfo pager)
        {
            List<ProductInfo> products = new List<ProductInfo>();

            //SqlDataAccess sqlDataAccess = new SqlDataAccess();

            //SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            //_con.Open();

            products = Seed_Product();
 
            //DataTable dt = _sqlDataAccess.ExecuteDataTable(null, "", CommandType.StoredProcedure, _con);

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in Helper.GetRows(dt, ref pager))
            //    {
            //        products.Add(Get_Product_Values(dr));
            //    }
            //}

            return products;
        }

        private List<ProductInfo> Seed_Product()
        {
            List<ProductInfo> retVal = new List<ProductInfo>();

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 1, Product_Title = "ABC", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 2, Product_Title = "EFG", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            retVal.Add(new ProductInfo() { Product_Id = 3, Product_Title = "HIJ", Product_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

            return retVal;
        }

        public ProductInfo Get_Product_By_Id(int product_Id)
        {
            ProductInfo product = new ProductInfo();

            //SqlDataAccess sqlDataAccess = new SqlDataAccess();

            //SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            //_con.Open();

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Product_Id", product_Id));

            //DataTable dt = _sqlDataAccess.ExecuteDataTable(param, "", CommandType.StoredProcedure, _con);

            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        product = Get_Product_Values(dr);
            //    }
            //}

            product = Seed_Product().Where(a => a.Product_Id == product_Id).Single();


            return product;
        }

        public int Insert_Product(ProductInfo product)
        {
            //SqlDataAccess sqlDataAccess = new SqlDataAccess();

            //SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Product_Values(product);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Product_Title", product.Product_Title));

            //param.Add(new SqlParameter("@Product_Description", product.Product_Description));

            //param.Add(new SqlParameter("@Language_Id", product.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", product.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", product.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", product.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", product.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", product.UpdatedBy));

            int product_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, "", CommandType.StoredProcedure, _con));

            return product_Id;
        }

        public void Update_Product(ProductInfo product)
        {
            //SqlDataAccess sqlDataAccess = new SqlDataAccess();

            //SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Product_Values(product);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Product_Id", product.Product_Id));

            //param.Add(new SqlParameter("@Product_Title", product.Product_Title));

            //param.Add(new SqlParameter("@Product_Description", product.Product_Description));

            //param.Add(new SqlParameter("@Language_Id", product.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", product.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", product.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", product.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", product.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", product.UpdatedBy));

            _sqlDataAccess.ExecuteNonQuery(param, "", CommandType.StoredProcedure, _con);
        }

        public ProductInfo Get_Product_Values(DataRow dr)
        {
            ProductInfo retVal = new ProductInfo();

            retVal.Product_Id = Convert.ToInt32(dr["Product_Id"]);

            retVal.Product_Title = Convert.ToString(dr["Product_Title"]);

            retVal.Product_Description = Convert.ToString(dr["Product_Description"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

            retVal.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

            retVal.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

            return retVal;
        }

        private List<SqlParameter> Set_Product_Values(ProductInfo product)
        {
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Product_Title", product.Product_Title));

            param.Add(new SqlParameter("@Product_Description", product.Product_Description));

            param.Add(new SqlParameter("@Language_Id", product.Language_Id));

            param.Add(new SqlParameter("@Is_Active", product.Is_Active));

            param.Add(new SqlParameter("@CreatedOn", product.CreatedOn));

            param.Add(new SqlParameter("@UpdatedOn", product.UpdatedOn));

            param.Add(new SqlParameter("@UpdatedBy", product.UpdatedBy));

            if (product.Product_Id == 0)
            {
                param.Add(new SqlParameter("@CreatedBy", product.CreatedBy));
            }

            if (product.Product_Id != 0)
            {
                param.Add(new SqlParameter("@Product_Id", product.Product_Id));
            }

            return param;
        }
    }
}






















            //if (products != null && products.Count > 0)
            //{
            //    int count = 0;

            //    count = products.Count();

            //    if (pager.IsPagingRequired)
            //    {
            //        products = products.Skip(pager.CurrentPage * pager.PageSize).Take(pager.PageSize).ToList();
            //    }

            //    pager.TotalRecords = count;

            //    int pages = (pager.TotalRecords + pager.PageSize - 1) / pager.PageSize;

            //    pager.TotalPages = pages;
            //}
