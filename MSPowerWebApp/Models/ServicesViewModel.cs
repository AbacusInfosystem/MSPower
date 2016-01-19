using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSPowerInfo;
using MSPowerWebApp.Common;

namespace MSPowerWebApp.Models
{
    public class ServicesViewModel
    {
        public ServicesInfo Service { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<ServicesInfo> Services { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Services_Filter Filter { get; set; }

        public List<LookUpInfo> Service_Categories { get; set; }

        public List<ServiceCategoryInfo> ServiceCategories { get; set; }

        public ServiceCategoryInfo Service_Category { get; set; }

        public string Language { get; set; }

        public ServicesViewModel()
        {
            Service = new ServicesInfo();

            Pager = new PaginationInfo();

            Services = new List<ServicesInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Service_Categories = new List<LookUpInfo>();

            Service_Category = new ServiceCategoryInfo();

        }
    }

    public class Services_Filter
    {
        public int Services_Id { get; set; }
    }
}