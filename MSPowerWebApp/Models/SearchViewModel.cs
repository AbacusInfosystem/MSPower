using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPowerWebApp.Models
{
    public class SearchViewModel
    {

        public int Language { get; set; }

        public int Product_Category_Id { get; set; }

        public string Keyword { get; set; }

        public string Compitetor { get; set; }


    }
}