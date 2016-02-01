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
    public class EventRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public EventRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<EventInfo> Get_Events(ref PaginationInfo pager, int language_Id)
        {
            List<EventInfo> eventss = new List<EventInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Events_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    eventss.Add(Get_Event_Values(dr));
                }
            }

            return eventss;
        }

        //private List<EventInfo> Seed_Event()

        //{

        //    List<EventInfo> retVal = new List<EventInfo>();

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 1, Event_Title = "ABC", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 2, Event_Title = "EFG", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new EventInfo() { Event_Id = 3, Event_Title = "HIJ", Event_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public EventInfo Get_Event_By_Id(int events_Id, int language_Id)
        {
            EventInfo events = new EventInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Event_Id", events_Id));

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Event_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    events = Get_Event_Values(dr);
                }
            }

            //events = Seed_Event().Where(a => a.Event_Id == events_Id).Single();


            return events;
        }

        public int Insert_Event(EventInfo events)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Event_Values(events);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Event_Title", events.Event_Title));

            //param.Add(new SqlParameter("@Event_Description", events.Event_Description));

            //param.Add(new SqlParameter("@Language_Id", events.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", events.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", events.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", events.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", events.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", events.UpdatedBy));

            int events_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Event_Sp.ToString(), CommandType.StoredProcedure, _con));

            return events_Id;
        }

        public void Update_Event(EventInfo events)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Event_Values(events);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@Event_Id", events.Event_Id));

            //param.Add(new SqlParameter("@Event_Title", events.Event_Title));

            //param.Add(new SqlParameter("@Event_Description", events.Event_Description));

            //param.Add(new SqlParameter("@Language_Id", events.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", events.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", events.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", events.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", events.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", events.UpdatedBy));

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_Event_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public EventInfo Get_Event_Values(DataRow dr)
       
        {
            EventInfo retVal = new EventInfo();

            retVal.Event_Id = Convert.ToInt32(dr["Event_Id"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.Event_Title = Convert.ToString(dr["Event_Title"]);

            retVal.Event_Description = Convert.ToString(dr["Event_Description"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_Event_Values(EventInfo events)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", events.Language_Id));

            param.Add(new SqlParameter("@Event_Title", events.Event_Title));

            param.Add(new SqlParameter("@Event_Description", events.Event_Description));

            param.Add(new SqlParameter("@Is_Active", events.Is_Active));

            param.Add(new SqlParameter("@Updated_On", events.Updated_On));

            param.Add(new SqlParameter("@Updated_By", events.Updated_By));

            if (events.Event_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", events.Created_On));

                param.Add(new SqlParameter("@Created_By", events.Created_By));
            }

            if (events.Event_Id != 0)
            {
                param.Add(new SqlParameter("@Event_Id", events.Event_Id));
            }

            return param;
        }

    }
}