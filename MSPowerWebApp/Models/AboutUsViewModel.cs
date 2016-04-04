using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;

namespace MSPowerWebApp.Models
{
    public class AboutUsViewModel
    {

        public AboutUsInfo AboutUs { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<AboutUsInfo> AboutUss { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public AboutUs_Filter Filter { get; set; }

        public AboutUsViewModel()
        {
            AboutUs = new AboutUsInfo();

            Pager = new PaginationInfo();

            AboutUss = new List<AboutUsInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }
    }

    public class AboutUs_Filter
    {
        public int About_Us_Id { get; set; }

    }
}
