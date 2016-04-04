using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;
using System.ComponentModel.DataAnnotations;
using CaptchaMvc;


namespace MSPowerWebApp.Models
{
    public class Job_ApplicationViewModel
    {

        public Job_ApplicationInfo Job_Application { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<Job_ApplicationInfo> Job_Applications { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Job_Application_Filter Filter { get; set; }

        public HttpPostedFileBase Upload_File { get; set; }

        public bool Is_DOCX_Exists { get; set; }

        public Job_ApplicationViewModel()
        
        {
            Job_Application = new Job_ApplicationInfo();

            Pager = new PaginationInfo();

            Job_Applications = new List<Job_ApplicationInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

        }

    }

    public class Job_Application_Filter
    
    {
        public int Job_Application_Id { get; set; }
 
    }
}



 







