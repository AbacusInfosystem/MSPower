﻿using System;
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


        // Services Store Procedures

        Get_Services_By_Id_Sp,

        Get_Services_Sp,

        Insert_Services_sp,

        Update_Services_Sp,


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

        Update_Job_Opening_Sp


    }


    public enum Language
    {
        en,

        ch,
    }
}
