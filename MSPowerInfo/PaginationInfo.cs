using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerInfo
{
    public class PaginationInfo
    {
        public PaginationInfo()
        
        {
            
            PageSize = 5;

            IsPagingRequired = true;
        }

        public int CurrentPage { get; set; }

        public bool IsPagingRequired { get; set; }

        public string PageHtmlString { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

    }
}
