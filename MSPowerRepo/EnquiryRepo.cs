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
  
    public class EnquiryRepo
    {

        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public EnquiryRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        public List<EnquiryInfo> Get_Enquirys(ref PaginationInfo pager, int language_Id)
        {
            List<EnquiryInfo> enquirys = new List<EnquiryInfo>();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Enquirys_Sp.ToString(), CommandType.StoredProcedure, _con);

            _con.Close();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in Helper.GetRows(dt, ref pager))
                {
                    enquirys.Add(Get_Enquiry_Values(dr));
                }
            }

            return enquirys;
        }

        public EnquiryInfo Get_Enquiry_By_Id(int enquiry_Id, int language_Id)
        {
            EnquiryInfo enquiry = new EnquiryInfo();

            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Enquiry_Id", enquiry_Id));

            param.Add(new SqlParameter("@Language_Id", language_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(param, StoredProcedures.Get_Enquiry_By_Id_Sp.ToString(), CommandType.StoredProcedure, _con);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    enquiry = Get_Enquiry_Values(dr);
                }
            }

            return enquiry;
        }

        public int Insert_Enquiry(EnquiryInfo enquiry)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Enquiry_Values(enquiry);

            int enquiry_Id = Convert.ToInt32(_sqlDataAccess.ExecuteScalar(param, StoredProcedures.Insert_Enquiry_Sp.ToString(), CommandType.StoredProcedure, _con));

            return enquiry_Id;
        }

        public void Update_Enquiry(EnquiryInfo enquiry)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            SqlConnection con = sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());

            _con.Open();

            List<SqlParameter> param = Set_Enquiry_Values(enquiry);
        }

        public EnquiryInfo Get_Enquiry_Values(DataRow dr)
       
        {
            EnquiryInfo retVal = new EnquiryInfo();

            retVal.Enquiry_Id = Convert.ToInt32(dr["Enquiry_Id"]);

            retVal.Language_Id = Convert.ToInt32(dr["Language_Id"]);

            retVal.Customer_Name = Convert.ToString(dr["Customer_Name"]);

            retVal.Customer_Address = Convert.ToString(dr["Customer_Address"]);

            retVal.Tel_No = Convert.ToString(dr["Tel_No"]);

            retVal.Email = Convert.ToString(dr["Email"]);

            retVal.Contact_Person = Convert.ToString(dr["Contact_Person"]);

            retVal.Contact_Person_Tel_No = Convert.ToString(dr["Contact_Person_Tel_No"]);

            retVal.Contact_Person_Mobile_No = Convert.ToString(dr["Contact_Person_Mobile_No"]);

            retVal.Enquiry_No = Convert.ToString(dr["Enquiry_No"]);

            retVal.Enquiry_Date = Convert.ToDateTime(dr["Enquiry_Date"]);

            retVal.Product_Name = Convert.ToString(dr["Product_Name"]);

            retVal.Quantity = Convert.ToInt32(dr["Quantity"]);

            retVal.Delivery = Convert.ToString(dr["Delivery"]);

            retVal.Created_On = Convert.ToDateTime(dr["Created_On"]);

            return retVal;
        }

        private List<SqlParameter> Set_Enquiry_Values(EnquiryInfo enquiry)
       
        {
            List<SqlParameter> param = new List<SqlParameter>();

            param.Add(new SqlParameter("@Language_Id", enquiry.Language_Id));

            param.Add(new SqlParameter("@Customer_Name", enquiry.Customer_Name));

            param.Add(new SqlParameter("@Customer_Address", enquiry.Customer_Address));

            param.Add(new SqlParameter("@Tel_No", enquiry.Tel_No));

            param.Add(new SqlParameter("@Email", enquiry.Email));

            param.Add(new SqlParameter("@Contact_Person", enquiry.Contact_Person));

            param.Add(new SqlParameter("@Contact_Person_Tel_No", enquiry.Contact_Person_Tel_No));

            param.Add(new SqlParameter("@Contact_Person_Mobile_No", enquiry.Contact_Person_Mobile_No));

            param.Add(new SqlParameter("@Enquiry_No", enquiry.Enquiry_No));

            param.Add(new SqlParameter("@Enquiry_Date", enquiry.Enquiry_Date));

            param.Add(new SqlParameter("@Product_Name", enquiry.Product_Name));

            param.Add(new SqlParameter("@Quantity", enquiry.Quantity));

            param.Add(new SqlParameter("@Delivery", enquiry.Delivery));

            param.Add(new SqlParameter("@Created_On", enquiry.Created_On));

            if (enquiry.Enquiry_Id != 0)
            {
                param.Add(new SqlParameter("@Enquiry_Id", enquiry.Enquiry_Id));
            }

            return param;
        }

    }
}
