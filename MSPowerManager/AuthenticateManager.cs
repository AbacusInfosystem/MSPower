using MSPowerInfo;
using MSPowerRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerManager
{
    public class AuthenticateManager
    {
        public UserInfo AuthenticateUser(string userName, string password)
        {
            AuthenticateRepo authRepo = new AuthenticateRepo();

            return authRepo.AuthenticateUser(userName, password);
        }

        public UserInfo SetSession(string username, string password)
        {
            AuthenticateRepo authRepo = new AuthenticateRepo();

            UserInfo retVal = new UserInfo();

            retVal = authRepo.SetSession(username, password);

            return retVal;
        }
    }
}
