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
    public class ContactUsRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public ContactUsRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<ContactUsInfo> Get_ContactUss(ref PaginationInfo pager)
        {
            List<ContactUsInfo> contactuss = new List<ContactUsInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();


            DataTable dt = _sqlDataAccess.ExecuteDataTable(null, StoredProcedures.Get_ContactUss_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    contactuss.Add(Get_ContactUs_Values(dr));
                }
            }

            return contactuss;
        }

        //private List<ContactUsInfo> Seed_ContactUs()
        //{
        //    List<ContactUsInfo> retVal = new List<ContactUsInfo>();

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description="<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 1, ContactUs_Title = "ABC", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 2, ContactUs_Title = "EFG", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = false, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    retVal.Add(new ContactUsInfo() { ContactUs_Id = 3, ContactUs_Title = "HIJ", ContactUs_Description = "<b>Hello World</b>", Language_Id = 1, Is_Active = true, CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now });

        //    return retVal;
        //}

        public ContactUsInfo Get_ContactUs_By_Id(int contactus_Id)
        {
            ContactUsInfo contactus = new ContactUsInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@ContactUs_Id", contactus_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_ContactUs_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    contactus = Get_ContactUs_Values(dr);
                }
            }

            //contactus = Seed_ContactUs().Where(a => a.ContactUs_Id == contactus_Id).Single();


            return contactus;
        }

        public int Insert_ContactUs(ContactUsInfo contactus)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_ContactUs_Values(contactus);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@ContactUs_Title", contactus.ContactUs_Title));

            //param.Add(new SqlParameter("@ContactUs_Description", contactus.ContactUs_Description));

            //param.Add(new SqlParameter("@Language_Id", contactus.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", contactus.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", contactus.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", contactus.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", contactus.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", contactus.UpdatedBy));

            int contactus_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_ContactUs_Sp.ToString(), CommandType.StoredProcedure, _con));

            return contactus_Id;
        }

        public void Update_ContactUs(ContactUsInfo contactus)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_ContactUs_Values(contactus);

            //List<SqlParameter> param = new List<SqlParameter>();

            //param.Add(new SqlParameter("@ContactUs_Id", contactus.ContactUs_Id));

            //param.Add(new SqlParameter("@ContactUs_Title", contactus.ContactUs_Title));

            //param.Add(new SqlParameter("@ContactUs_Description", contactus.ContactUs_Description));

            //param.Add(new SqlParameter("@Language_Id", contactus.Language_Id));

            //param.Add(new SqlParameter("@Is_Active", contactus.Is_Active));

            //param.Add(new SqlParameter("@CreatedOn", contactus.CreatedOn));

            //param.Add(new SqlParameter("@CreatedBy", contactus.CreatedBy));

            //param.Add(new SqlParameter("@UpdatedOn", contactus.UpdatedOn));

            //param.Add(new SqlParameter("@UpdatedBy", contactus.UpdatedBy));

            _sqlDataAccess.ExecuteNonQuery(param, StoredProcedures.Update_ContactUs_Sp.ToString(), CommandType.StoredProcedure, _con);

        }

        public ContactUsInfo Get_ContactUs_Values(DataRow dr)
       
        {
            ContactUsInfo retVal = new ContactUsInfo();

            retVal.ContactUs_Id = Convert.ToInt32(dr["ContactUs_Id"]);

            retVal.ContactUs_Title = Convert.ToString(dr["ContactUs_Title"]);

            retVal.ContactUs_Address = Convert.ToString(dr["ContactUs_Address"]);

            retVal.Latitude = Convert.ToString(dr["Latitude"]);

            retVal.Longitude = Convert.ToString(dr["Longitude"]);

            retVal.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            retVal.Created_By = Convert.ToInt32(dr["Created_By"]);

            retVal.Updated_By = Convert.ToInt32(dr["Updated_By"]);

            retVal.Updated_On = Convert.ToDateTime(dr["Updated_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_ContactUs_Values(ContactUsInfo contactus)
       
        {
            
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@ContactUs_Title", contactus.ContactUs_Title));

            param.Add(new SqlParameter("@ContactUs_Address", contactus.ContactUs_Address));

            param.Add(new SqlParameter("@Latitude", contactus.Latitude));

            param.Add(new SqlParameter("@Longitude", contactus.Longitude));

            param.Add(new SqlParameter("@Is_Active", contactus.Is_Active));

            param.Add(new SqlParameter("@Updated_On", contactus.Updated_On));

            param.Add(new SqlParameter("@Updated_By", contactus.Updated_By));

            if (contactus.ContactUs_Id == 0)
            {

                param.Add(new SqlParameter("@Created_On", contactus.Created_On));

                param.Add(new SqlParameter("@Created_By", contactus.Created_By));
            }

            if (contactus.ContactUs_Id != 0)
            {
                param.Add(new SqlParameter("@ContactUs_Id", contactus.ContactUs_Id));
            }

            return param;
        }

    }
}
