using DataAccess.Sql;
using MSPowerInfo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerRepo
{
    public class AjaxRepo
    {
        SqlDataAccess _sqlDataAccess = null;

        SqlConnection _con = null;

        public AjaxRepo()
        {
            _sqlDataAccess = new SqlDataAccess();
            
            _con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        }

        #region Attachments

        public long Insert_Attachment(AttachmentsInfo attachment)
        {
            _con.Open();

            long attachemnt_Id = Convert.ToInt64(_sqlDataAccess.ExecuteScalar(Set_Values_In_Attachment(attachment), "", CommandType.StoredProcedure, _con)); //StoredProcedures.Insert_Attachment_Sp.ToString()

            return attachemnt_Id;
        }

        public void Delete_Attachment_By_Id(long attachment_Id)
        {

            _con.Open();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attachment_Id", attachment_Id));

            _sqlDataAccess.ExecuteNonQuery(sqlParams, "", CommandType.StoredProcedure, _con); // StoredProcedures.Delete_Attachment_By_Id.ToString()
        }

        public List<AttachmentsInfo> Get_Attachments_By_Ref_Type_Ref_Id(int ref_Type, int ref_Id)
        {
            List<AttachmentsInfo> attachments = new List<AttachmentsInfo>();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Ref_Type", ref_Type));

            sqlparam.Add(new SqlParameter("@Ref_Id", ref_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(sqlparam, "", CommandType.StoredProcedure, _con); //StoredProcedures.Get_Attachments_By_Ref_Type_Ref_Id_Sp.ToString()

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                attachments.Add(Get_Attachments_Values(dr));
            }

            return attachments;
        }

        public AttachmentsInfo Get_Attachment_By_Id(long attachment_Id)
        {
            AttachmentsInfo attachments = new AttachmentsInfo();

            List<SqlParameter> sqlparam = new List<SqlParameter>();

            sqlparam.Add(new SqlParameter("@Attachment_Id", attachment_Id));

            DataTable dt = _sqlDataAccess.ExecuteDataTable(sqlparam, "", CommandType.StoredProcedure, _con); // StoredProcedures.Get_Attachments_By_Id_Sp.ToString()

            List<DataRow> drList = new List<DataRow>();

            drList = dt.AsEnumerable().ToList();

            foreach (DataRow dr in drList)
            {
                attachments = Get_Attachments_Values(dr);
            }

            return attachments;
        }

        private List<SqlParameter> Set_Values_In_Attachment(AttachmentsInfo attachment)
        {
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Ref_Id", attachment.Ref_Id));
            sqlParams.Add(new SqlParameter("@Ref_Type", attachment.Ref_Type));
            sqlParams.Add(new SqlParameter("@Document_Name", attachment.Document_Name));
            sqlParams.Add(new SqlParameter("@CreatedBy", attachment.CreatedBy));
            sqlParams.Add(new SqlParameter("@CreatedOn", attachment.CreatedOn));
            sqlParams.Add(new SqlParameter("@UpdatedBy", attachment.UpdatedBy));
            sqlParams.Add(new SqlParameter("@UpdatedOn", attachment.UpdatedOn));
            sqlParams.Add(new SqlParameter("@Remark", attachment.Remark));    //

            return sqlParams;
        }

        private AttachmentsInfo Get_Attachments_Values(DataRow dr)
        {
            AttachmentsInfo attachments = new AttachmentsInfo();

            attachments.Attachment_Id = Convert.ToInt64(dr["Attachment_Id"]);
            attachments.Ref_Id = Convert.ToInt32(dr["Ref_Id"]);
            attachments.Ref_Type = Convert.ToInt32(dr["Ref_Type"]);
            attachments.Document_Name = Convert.ToString(dr["Document_Name"]);
            attachments.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);
            attachments.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);
            attachments.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);
            attachments.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);
            //attachments.Remark = Convert.ToString(dr["Remark"]);
            return attachments;
        }

        #endregion

    }
}
