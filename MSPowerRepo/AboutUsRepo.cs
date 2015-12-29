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

        public List<AboutUsInfo> Get_AboutUss(ref PaginationInfo pager)
        {
            List<AboutUsInfo> aboutuss = new List<AboutUsInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();


            DataTable dt = _sqlDataAccess.ExecuteDataTable(null, StoredProcedures.Get_AboutUss_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    aboutuss.Add(Get_AboutUs_Values(dr));
                }
            }

            return aboutuss;
        }

        //private List<AboutUsInfo> Seed_AboutUs()
        //{
        //    List<AboutUsInfo> retVal = new List<AboutUsInfo>();

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 1, AboutUs_Title = "ABC", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 2, AboutUs_Title = "EFG", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new AboutUsInfo() { AboutUs_Id = 3, AboutUs_Title = "HIJ", AboutUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public AboutUsInfo Get_AboutUs_By_Id(int aboutus_Id)
        {
            AboutUsInfo aboutus = new AboutUsInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@About_Us_Id", aboutus_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_AboutUs_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    aboutus = Get_AboutUs_Values(dr);
                }
            }

            //aboutus = Seed_AboutUs().Where(a => a.AboutUs_Id == aboutus_Id).Single();


            return aboutus;
        }

        public int Insert_AboutUs(AboutUsInfo aboutus)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_AboutUs_Values(aboutus);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@AboutUs_Title", aboutus.AboutUs_Title));

            //param.Add(new SqlParameter("@AboutUs_Description", aboutus.AboutUs_Description));

            //param.Add(new SqlParameter("@Language_Id", aboutus.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", aboutus.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", aboutus.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", aboutus.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", aboutus.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", aboutus.UpdatedBy));

            int aboutus_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_AboutUs_Sp.ToString(), CommandType.StoredProcedure, _con));

            return aboutus_Id;
        }

        public void Update_AboutUs(AboutUsInfo aboutus)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_AboutUs_Values(aboutus);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@AboutUs_Id", aboutus.AboutUs_Id));

            //param.Add(new SqlParameter("@AboutUs_Title", aboutus.AboutUs_Title));

            //param.Add(new SqlParameter("@AboutUs_Description", aboutus.AboutUs_Description));

            //param.Add(new SqlParameter("@Language_Id", aboutus.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", aboutus.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", aboutus.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", aboutus.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", aboutus.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", aboutus.UpdatedBy));

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
