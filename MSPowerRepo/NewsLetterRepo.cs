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
    public class NewsLetterRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public NewsLetterRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<NewsLetterInfo> Get_NewsLetters(ref PaginationInfo pager, int language_Id)
        {
            List<NewsLetterInfo> newsletters = new List<NewsLetterInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_NewsLetters_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    newsletters.Add(Get_NewsLetter_Values(dr));
                }
            }

            return newsletters;
        }

        //private List<NewsLetterInfo> Seed_NewsLetter()
        //{
        //    List<NewsLetterInfo> retVal = new List<NewsLetterInfo>();

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 1, NewsLetter_Title = "ABC", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 2, NewsLetter_Title = "EFG", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new NewsLetterInfo() { NewsLetter_Id = 3, NewsLetter_Title = "HIJ", NewsLetter_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public NewsLetterInfo Get_NewsLetter_By_Id(int newsletter_Id, int language_Id)
        {
            NewsLetterInfo newsletter = new NewsLetterInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@NewsLetter_Id", newsletter_Id));

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_NewsLetter_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    newsletter = Get_NewsLetter_Values(dr);
                }
            }

            //newsletter = Seed_NewsLetter().Where(a => a.NewsLetter_Id == newsletter_Id).Single();


            return newsletter;
        }

        public int Insert_NewsLetter(NewsLetterInfo newsletter)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_NewsLetter_Values(newsletter);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@NewsLetter_Title", newsletter.NewsLetter_Title));

            //param.Add(new SqlParameter("@NewsLetter_Description", newsletter.NewsLetter_Description));

            //param.Add(new SqlParameter("@Language_Id", newsletter.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", newsletter.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", newsletter.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", newsletter.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", newsletter.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", newsletter.UpdatedBy));

            int newsletter_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_NewsLetter_Sp.ToString(), CommandType.StoredProcedure, _con));

            return newsletter_Id;
        }

        public void Update_NewsLetter(NewsLetterInfo newsletter)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_NewsLetter_Values(newsletter);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@NewsLetter_Id", newsletter.NewsLetter_Id));

            //param.Add(new SqlParameter("@NewsLetter_Title", newsletter.NewsLetter_Title));

            //param.Add(new SqlParameter("@NewsLetter_Description", newsletter.NewsLetter_Description));

            //param.Add(new SqlParameter("@Language_Id", newsletter.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", newsletter.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", newsletter.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", newsletter.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", newsletter.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", newsletter.UpdatedBy));

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_NewsLetter_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public NewsLetterInfo Get_NewsLetter_Values(DataRow dr)
       
        {
            NewsLetterInfo retVal = new NewsLetterInfo();

            retVal.NewsLetter_Id = Convert.ToInt32(dr["NewsLetter_Id"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.NewsLetter_Title = Convert.ToString(dr["NewsLetter_Title"]);

            retVal.NewsLetter_Description = Convert.ToString(dr["NewsLetter_Description"]);

            retVal.NewLetter_Release_Date = Convert.ToDateTime(dr["NewsLetter_Release_Date"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_NewsLetter_Values(NewsLetterInfo newsletter)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", newsletter.Language_Id));

            param.Add(new SqlParameter("@NewsLetter_Title", newsletter.NewsLetter_Title));

            param.Add(new SqlParameter("@NewsLetter_Description", newsletter.NewsLetter_Description));

            param.Add(new SqlParameter("NewsLetter_Release_Date", newsletter.NewLetter_Release_Date));

            param.Add(new SqlParameter("@Is_Active", newsletter.Is_Active));

            param.Add(new SqlParameter("@Updated_On", newsletter.Updated_On));

            param.Add(new SqlParameter("@Updated_By", newsletter.Updated_By));

            if (newsletter.NewsLetter_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", newsletter.Created_On));

                param.Add(new SqlParameter("@Created_By", newsletter.Created_By));
            }

            if (newsletter.NewsLetter_Id != 0)
            {
                param.Add(new SqlParameter("@NewsLetter_Id", newsletter.NewsLetter_Id));
            }

            return param;
        }

    }
}
