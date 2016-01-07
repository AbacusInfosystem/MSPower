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

        // Authentication and Session Store Procedures

        Authenticate_User_sp,

        Get_Session_Data_sp,


        // Products Store Procedures

        Get_Product_By_Id_Sp,

        Get_Products_Sp,

        Insert_Product_Sp,

        Update_Product_Sp,

        

        // Products_Detail Store Procedures

        Get_Product_Detail_By_Id_Sp,

        Get_Product_Details_Sp,

        Get_Columns_Sp,

        Get_Column_By_Id_Sp,

        Get_Product_Categories_Sp,

        Get_Product_Volts_Sp,

        Get_Product_Columns_Sp,

        Get_Product_Details_Headers_Sp,

        Insert_Product_Detail_Sp,

        Update_Product_Detail_Sp,

        // Services Store Procedures

        Get_Services_By_Id_Sp,

        Get_Services_Sp,

        Insert_Services_sp,

        Update_Services_Sp,

        Get_Services_Categories_Sp,

        // NewsLetter Store Procedures

        Get_NewsLetter_By_Id_Sp,

        Get_NewsLetters_Sp,

        Insert_NewsLetter_Sp,

        Update_NewsLetter_Sp,


        // ContactUs Store Procedures

        Get_ContactUs_By_Id_Sp,

        Get_ContactUss_Sp,

        Insert_ContactUs_Sp,

        Update_ContactUs_Sp,



        // Job Opening Store Procedures

        Get_Job_Opening_By_Id_Sp,

        Get_Job_Openings_Sp,

        Insert_Job_Opening_Sp,

        Update_Job_Opening_Sp,



        // Enquiry Store Procedures

        Get_Enquiry_By_Id_Sp,

        Get_Enquirys_Sp,

        Insert_Enquiry_Sp,


         // Job_Application Store Procedures

        Get_Job_Application_By_Id_Sp,

        Get_Job_Applications_Sp,

        Insert_Job_Application_Sp,


        // About Us Store Procedures

        Get_AboutUs_By_Id_Sp,

        Get_AboutUss_Sp,

        Insert_AboutUs_Sp,

        Update_AboutUs_Sp


    }
    
    public enum Language
    {
        en = 1,

        ch = 2,
    }
}
