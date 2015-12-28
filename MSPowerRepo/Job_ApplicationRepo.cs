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
    public class Job_ApplicationRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public Job_ApplicationRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<Job_ApplicationInfo> Get_Job_Applications(ref PaginationInfo pager)
        {
            List<Job_ApplicationInfo> job_applications = new List<Job_ApplicationInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();


            DataTable dt = _sqlDataAccess.ExecuteDataTable(null, StoredProcedures.Get_Job_Applications_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    job_applications.Add(Get_Job_Application_Values(dr));
                }
            }

            return job_applications;
        }

        //private List<Job_ApplicationInfo> Seed_Job_Application()
        //{
        //    List<Job_ApplicationInfo> retVal = new List<Job_ApplicationInfo>();

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 1, Job_Application_Title = "ABC", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 2, Job_Application_Title = "EFG", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_ApplicationInfo() { Job_Application_Id = 3, Job_Application_Title = "HIJ", Job_Application_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public Job_ApplicationInfo Get_Job_Application_By_Id(int job_application_Id)
        {
            Job_ApplicationInfo job_application = new Job_ApplicationInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Job_Application_Id", job_application_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Job_Application_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    job_application = Get_Job_Application_Values(dr);
                }
            }

            //job_application = Seed_Job_Application().Where(a => a.Job_Application_Id == job_application_Id).Single();


            return job_application;
        }

        public int Insert_Job_Application(Job_ApplicationInfo job_application)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Job_Application_Values(job_application);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Job_Application_Title", job_application.Job_Application_Title));

            //param.Add(new SqlParameter("@Job_Application_Description", job_application.Job_Application_Description));

            //param.Add(new SqlParameter("@Language_Id", job_application.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", job_application.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", job_application.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", job_application.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", job_application.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", job_application.UpdatedBy));

            int job_application_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Job_Application_Sp.ToString(), CommandType.StoredProcedure, _con));

            return job_application_Id;
        }

        public void Update_Job_Application(Job_ApplicationInfo job_application)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Job_Application_Values(job_application);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Job_Application_Id", job_application.Job_Application_Id));

            //param.Add(new SqlParameter("@Job_Application_Title", job_application.Job_Application_Title));

            //param.Add(new SqlParameter("@Job_Application_Description", job_application.Job_Application_Description));

            //param.Add(new SqlParameter("@Language_Id", job_application.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", job_application.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", job_application.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", job_application.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", job_application.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", job_application.UpdatedBy));

            //_sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Job_Application_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public Job_ApplicationInfo Get_Job_Application_Values(DataRow dr)
       
        {
            Job_ApplicationInfo retVal = new Job_ApplicationInfo();

            retVal.Job_Application_Id = Convert.ToInt32(dr["Job_Application_Id"]);

            retVal.First_Name = Convert.ToString(dr["First_Name"]);

            retVal.Last_Name = Convert.ToString(dr["Last_Name"]);

            retVal.Email = Convert.ToString(dr["Email"]);

            retVal.Reference = Convert.ToString(dr["Reference"]);

            retVal.Additional_Information = Convert.ToString(dr["Additional_Information"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_Job_Application_Values(Job_ApplicationInfo job_application)
       
        {
            

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@First_Name", job_application.First_Name));

            param.Add(new SqlParameter("@Last_Name", job_application.Last_Name));

            param.Add(new SqlParameter("@Email", job_application.Email));

            param.Add(new SqlParameter("@Reference", job_application.Reference));

            param.Add(new SqlParameter("@Additional_Information", job_application.Additional_Information));

            param.Add(new SqlParameter("@Created_On", job_application.Created_On));

            if (job_application.Job_Application_Id != 0)
            {
                param.Add(new SqlParameter("@Job_Application_Id", job_application.Job_Application_Id));
            }

            return param;
        }

    }
}
