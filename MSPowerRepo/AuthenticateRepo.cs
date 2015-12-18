using DataAccess.Sql;
using ExceptionManagement.Logger;
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
    public class AuthenticateRepo
    {
        private string _sqlCon = string.Empty;

        private SqlDataAccess _sqlDataAccess = null;

        public AuthenticateRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();

            _sqlDataAccess = new SqlDataAccess();
        }

        public UserInfo AuthenticateUser(string userName, string password)
        {
            UserInfo retVal = new UserInfo();

            using (SqlConnection con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString()))
            {
                try
                {
                    con.Open();

                    List<SqlParameter> sqlparam = new List<SqlParameter>();

                    sqlparam.Add(new SqlParameter("@User_Name", userName));

                    sqlparam.Add(new SqlParameter("@Password", password));

                    SqlDataReader dataReader = _sqlDataAccess.ExecuteDataReader(sqlparam, StoredProcedures.Authenticate_User_sp.ToString(), CommandType.StoredProcedure, con);

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            retVal.UserId = Convert.ToInt32(dataReader["UserId"]);

                            retVal.Is_Active = Convert.ToBoolean(dataReader["Is_Active"]);
                        }
                    }

                    dataReader.Close();

                }

                catch (Exception ex)
                
                {
                    Logger.Error("UserRepo - AuthenticateLoginCredentials: " + ex.ToString());

                    throw;
                }

                finally
                
                {
                    CloseConnection(con);
                }
            
            }

            return retVal;
        }

        public UserInfo SetSession(string userName, string password)
        
        {
            UserInfo userInfo = new UserInfo();

            using (SqlConnection con = _sqlDataAccess.GetConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString()))
           
            {
               
                try
               
                {
                    con.Open();

                    List<SqlParameter> sqlparam = new List<SqlParameter>();

                    sqlparam.Add(new SqlParameter("@User_Name", userName));

                    sqlparam.Add(new SqlParameter("@Password", password));

                    SqlDataReader dataReader = _sqlDataAccess.ExecuteDataReader(sqlparam, StoredProcedures.Authenticate_User_sp.ToString(), CommandType.StoredProcedure, con);

                    if (dataReader.HasRows)
                  
                    {
                        while (dataReader.Read())
                       
                        {
                            userInfo.UserId = Convert.ToInt32(dataReader["UserId"]);

                            userInfo.Name = Convert.ToString(dataReader["Name"]);
                        }
                   
                    }

                    dataReader.Close();

                }

                catch (Exception ex)
                
                {
                    Logger.Error("UserRepo - SetSession: " + ex.ToString());

                    throw;
                }

                finally
               
                {
                    CloseConnection(con);
                }
            }

            return userInfo;
        }

        public static void CloseConnection(SqlConnection con)
        {
            if (con != null)
                con.Close();
        }
    }
}
