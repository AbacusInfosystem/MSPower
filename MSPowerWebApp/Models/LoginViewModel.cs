using MSPowerInfo;
using MSPowerWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPowerWebApp.Models
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            User = new UserInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public UserInfo User { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        
    }
}