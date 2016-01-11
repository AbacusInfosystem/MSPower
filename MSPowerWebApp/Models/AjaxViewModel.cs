using MSPowerInfo;
using MSPowerWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPowerWebApp.Models
{
    public class AjaxViewModel
    {

        public AjaxViewModel()
        {
            Attachment = new AttachmentsInfo();

            Attachments = new List<AttachmentsInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public AttachmentsInfo Attachment { get; set; }

        public List<AttachmentsInfo> Attachments { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
    }
}