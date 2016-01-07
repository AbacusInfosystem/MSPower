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

        public List<ServicesInfo> Get_Services(ref PaginationInfo pager, int language_Id)
        {
            List<ServicesInfo> services = new List<ServicesInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Services_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    services.Add(Get_Services_Values(dr));
                }
            }

            return services;
        }

        public ServicesInfo Get_Services_By_Id(int service_Id, int language_Id)
        {
            ServicesInfo services = new ServicesInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Service_Id", service_Id));

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Services_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    services = Get_Services_Values(dr);
                }
            }

            return services;
        }

        public int Insert_Services(ServicesInfo service)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Services_Values(service);

            int services_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Services_sp.ToString(), CommandType.StoredProcedure, _con));

            return services_Id;
        }

        public void Update_Services(ServicesInfo service)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Services_Values(service);

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Services_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public ServicesInfo Get_Services_Values(DataRow dr)
       
        {
            ServicesInfo retVal = new ServicesInfo();

            retVal.Service_Id = Convert.ToInt32(dr["Service_Id"]);

            retVal.Service_Title = Convert.ToString(dr["Service_Title"]);

            retVal.Service_Category_Id = Convert.ToInt32(dr["Service_Category_Id"]);

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

            param.Add(new SqlParameter("Service_Category_Id", services.Service_Category_Id));

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

        public List<LookUpInfo> Get_Services_Categories(int language_Id)
        {
            List<LookUpInfo> services_categories = new List<LookUpInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Services_Categories_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LookUpInfo service_category = new LookUpInfo();

                    service_category.Id = Convert.ToInt32(dr["Service_Category_Id"]);

                    service_category.Value = Convert.ToString(dr["Service_Category"]);

                    services_categories.Add(service_category);
                }
            }

            return services_categories;
        }
    
    }
}























    