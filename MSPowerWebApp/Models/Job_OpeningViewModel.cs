using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;


namespace MSPowerWebApp.Models
{
    public class Job_OpeningViewModel
    {

        public Job_OpeningInfo Job_Opening { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<Job_OpeningInfo> Job_Openings { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Job_Opening_Filter Filter { get; set; }

        public Job_OpeningViewModel()

        {
            Job_Opening = new Job_OpeningInfo();

            Pager = new PaginationInfo();

            Job_Openings = new List<Job_OpeningInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

        }
    }

    public class Job_Opening_Filter
    {
        public int Job_Opening_Id { get; set; }

    }
}