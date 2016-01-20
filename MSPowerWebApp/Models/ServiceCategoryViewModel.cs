using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MSPowerInfo;
using MSPowerWebApp.Common;
namespace MSPowerWebApp.Models

{
    public class ServiceCategoryViewModel
    {
        public ServiceCategoryInfo ServiceCategory { get; set; }

        public List<ServiceCategoryInfo> ServiceCategories { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public ServiceCategory_Filter Filter { get; set; }

        public string Language { get; set; }


        public ServiceCategoryViewModel()
        {
            
            ServiceCategory = new ServiceCategoryInfo();

            Pager = new PaginationInfo();

            ServiceCategories = new List<ServiceCategoryInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();

        }
    }

    public class ServiceCategory_Filter
    {
        public int Service_Category_Id { get; set; }
    }
}