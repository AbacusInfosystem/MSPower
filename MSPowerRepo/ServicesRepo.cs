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
    public class ServicesRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public ServicesRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<ServicesInfo> Get_Services(ref PaginationInfo pager)
        {
            List<ServicesInfo> services = new List<ServicesInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();


            DataTable dt = _sqlDataAccess.ExecuteDataTable(null, StoredProcedures.Get_Services_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    services.Add(Get_Services_Values(dr));
                }
            }

            return services;
        }

        //private List<ServicesInfo> Seed_Services()

        //{
        //    List<ServicesInfo> retVal = new List<ServicesInfo>();

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 1, Product_Title = "ABC", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 2, Product_Title = "EFG", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ServicesInfo() { Services_Id = 3, Product_Title = "HIJ", Services_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public ServicesInfo Get_Services_By_Id(int service_Id)
        {
            ServicesInfo services = new ServicesInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Service_Id", service_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Services_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    services = Get_Services_Values(dr);
                }
            }

            //Services = Seed_Services().Where(a => a.Services_Id == Services_Id).Single();


            return services;
        }

        public int Insert_Services(ServicesInfo service)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Services_Values(service);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Services_Title", services.Services_Title));

            //param.Add(new SqlParameter("@Services_Description", services.Services_Description));

            //param.Add(new SqlParameter("@Language_Id", services.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", services.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", services.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", services.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", services.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", services.UpdatedBy));

            int services_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Services_sp.ToString(), CommandType.StoredProcedure, _con));

            return services_Id;
        }

        public void Update_Services(ServicesInfo service)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Services_Values(service);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Services_Id", services.Services_Id));

            //param.Add(new SqlParameter("@Services_Title", services.Product_Title));

            //param.Add(new SqlParameter("@Services_Description", services.Services_Description));

            //param.Add(new SqlParameter("@Language_Id", services.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", services.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", services.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", services.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", services.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", services.UpdatedBy));

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Services_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public ServicesInfo Get_Services_Values(DataRow dr)
       
        {
            ServicesInfo retVal = new ServicesInfo();

            retVal.Service_Id = Convert.ToInt32(dr["Service_Id"]);

            retVal.Service_Title = Convert.ToString(dr["Service_Title"]);

            retVal.Service_Description = Convert.ToString(dr["Service_Description"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_Services_Values(ServicesInfo services)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Service_Title", services.Service_Title));

            param.Add(new SqlParameter("@Service_Description", services.Service_Description));

            param.Add(new SqlParameter("@Language_Id", services.Language_Id));

            param.Add(new SqlParameter("@Is_Active", services.Is_Active));

            param.Add(new SqlParameter("@Updated_On", services.Updated_On));

            param.Add(new SqlParameter("@Updated_By", services.Updated_By));

            if (services.Service_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", services.Created_On));

                param.Add(new SqlParameter("@Created_By", services.Created_By));
            }

            if (services.Service_Id != 0)
            {
                param.Add(new SqlParameter("@Service_Id", services.Service_Id));
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


    