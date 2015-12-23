﻿using System;
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
    public class Job_OpeningRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public Job_OpeningRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<Job_OpeningInfo> Get_Job_Openings(ref PaginationInfo pager)
        {
            List<Job_OpeningInfo> job_openings = new List<Job_OpeningInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();


            DataTable dt = _sqlDataAccess.ExecuteDataTable(null, StoredProcedures.Get_Job_Openings_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    job_openings.Add(Get_Job_Opening_Values(dr));
                }
            }

            return job_openings;
        }

        //private List<Job_OpeningInfo> Seed_Job_Opening()
        //{
        //    List<Job_OpeningInfo> retVal = new List<Job_OpeningInfo>();

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 1, Job_Opening_Title = "ABC", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 2, Job_Opening_Title = "EFG", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new Job_OpeningInfo() { Job_Opening_Id = 3, Job_Opening_Title = "HIJ", Job_Opening_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public Job_OpeningInfo Get_Job_Opening_By_Id(int job_opening_Id)
        {
            Job_OpeningInfo job_opening = new Job_OpeningInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Job_Opening_Id", job_opening_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Job_Opening_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    job_opening = Get_Job_Opening_Values(dr);
                }
            }

            //job_opening = Seed_Job_Opening().Where(a => a.Job_Opening_Id == job_opening_Id).Single();


            return job_opening;
        }

        public int Insert_Job_Opening(Job_OpeningInfo job_opening)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Job_Opening_Values(job_opening);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Job_Opening_Title", job_opening.Job_Opening_Title));

            //param.Add(new SqlParameter("@Job_Opening_Description", job_opening.Job_Opening_Description));

            //param.Add(new SqlParameter("@Language_Id", job_opening.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", job_opening.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", job_opening.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", job_opening.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", job_opening.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", job_opening.UpdatedBy));

            int job_opening_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Job_Opening_Sp.ToString(), CommandType.StoredProcedure, _con));

            return job_opening_Id;
        }

        public void Update_Job_Opening(Job_OpeningInfo job_opening)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Job_Opening_Values(job_opening);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Job_Opening_Id", job_opening.Job_Opening_Id));

            //param.Add(new SqlParameter("@Job_Opening_Title", job_opening.Job_Opening_Title));

            //param.Add(new SqlParameter("@Job_Opening_Description", job_opening.Job_Opening_Description));

            //param.Add(new SqlParameter("@Language_Id", job_opening.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", job_opening.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", job_opening.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", job_opening.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", job_opening.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", job_opening.UpdatedBy));

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Job_Opening_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public Job_OpeningInfo Get_Job_Opening_Values(DataRow dr)
       
        {
            Job_OpeningInfo retVal = new Job_OpeningInfo();

            retVal.Job_Opening_Id = Convert.ToInt32(dr["Job_Opening_Id"]);

            retVal.Job_Title = Convert.ToString(dr["Job_Title"]);

            retVal.Job_Description = Convert.ToString(dr["Job_Description"]);

            retVal.CTC = Convert.ToString(dr["CTC"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_Job_Opening_Values(Job_OpeningInfo job_opening)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Job_Title", job_opening.Job_Title));

            param.Add(new SqlParameter("@Job_Description", job_opening.Job_Description));

            param.Add(new SqlParameter("@CTC", job_opening.CTC));

            param.Add(new SqlParameter("@Is_Active", job_opening.Is_Active));

            param.Add(new SqlParameter("@Updated_On", job_opening.Updated_On));

            param.Add(new SqlParameter("@Updated_By", job_opening.Updated_By));

            if (job_opening.Job_Opening_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", job_opening.Created_On));

                param.Add(new SqlParameter("@Created_By", job_opening.Created_By));
            }

            if (job_opening.Job_Opening_Id != 0)
            {
                param.Add(new SqlParameter("@Job_Opening_Id", job_opening.Job_Opening_Id));
            }

            return param;
        }

    }
}
