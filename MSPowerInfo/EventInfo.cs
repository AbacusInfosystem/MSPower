using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MSPowerInfo
{
    public class EventInfo
    {

        public int Event_Id { get; set; }

        public int EventId { get; set; }

        public int Language_Id { get; set; }

        public string Event_Title { get; set; }

        [AllowHtml]

        public string Event_Description { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

    }
}
