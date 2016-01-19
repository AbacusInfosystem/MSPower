using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;

namespace MSPowerWebApp.Models
{
    public class EventViewModel
    {

        public EventInfo Event { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<EventInfo> Events { get; set; }

        public List<string> File_Name { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public Event_Filter Filter { get; set; }

        public HttpPostedFileBase Upload_File { get; set; }

        public EventViewModel()
        {

            Event = new EventInfo();

            Pager = new PaginationInfo();

            Events = new List<EventInfo>();

            File_Name = new List<string>();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Filter = new Event_Filter();
        }

    }

    public class Event_Filter
    {
        public int Event_Id { get; set; }
    }
}