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
    public class AboutUsRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public AboutUsRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<AboutUsInfo> Get_AboutUss(ref PaginationInfo pager, int language_Id)
        {
            List<AboutUsInfo> aboutuss = new List<AboutUsInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_AboutUss_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    aboutuss.Add(Get_AboutUs_Values(dr));
                }
            }

            return aboutuss;
        }

        public AboutUsInfo Get_AboutUs_By_Id(int aboutus_Id, int language_Id)
        {
            AboutUsInfo aboutus = new AboutUsInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@About_Us_Id", aboutus_Id));

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_AboutUs_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    aboutus = Get_AboutUs_Values(dr);
                }
            }

            return aboutus;
        }

        public int Insert_AboutUs(AboutUsInfo aboutus)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_AboutUs_Values(aboutus);

            int aboutus_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_AboutUs_Sp.ToString(), CommandType.StoredProcedure, _con));

            return aboutus_Id;
        }

        public void Update_AboutUs(AboutUsInfo aboutus)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_AboutUs_Values(aboutus);

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_AboutUs_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public AboutUsInfo Get_AboutUs_Values(DataRow dr)
       
        {
            AboutUsInfo retVal = new AboutUsInfo();

            retVal.About_Us_Id = Convert.ToInt32(dr["About_Us_Id"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.About_Us_Description = Convert.ToString(dr["About_Us_Description"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_AboutUs_Values(AboutUsInfo aboutus)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", aboutus.Language_Id));

            param.Add(new SqlParameter("@About_Us_Description", aboutus.About_Us_Description));

            param.Add(new SqlParameter("@Updated_On", aboutus.Updated_On));

            param.Add(new SqlParameter("@Updated_By", aboutus.Updated_By));

            if (aboutus.About_Us_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", aboutus.Created_On));

                param.Add(new SqlParameter("@Created_By", aboutus.Created_By));
            }

            if (aboutus.About_Us_Id != 0)
            {
                param.Add(new SqlParameter("@About_Us_Id", aboutus.About_Us_Id));
            }

            return param;
        }

    }
}
