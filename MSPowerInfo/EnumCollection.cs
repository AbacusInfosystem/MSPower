using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerInfo
{
    public enum MessageType
    {
        Danger,

        Info,
        
        Warning,
     
        Success
    }

    public enum StoredProcedures
    {
        Authenticate_User_sp,

        Get_Session_Data_sp
    }

    public enum Language
    {
        en,

        ch,
    }

    public enum RefType
    {
        Product = 1,

        Services = 2,
        
        Appliction = 3,
        
        NewsLetters = 4,
    }


}
