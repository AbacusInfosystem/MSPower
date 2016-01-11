using MSPowerWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MSPowerWebApp.Models
{
    public class ImageUploadViewModel
    {
        public ImageUploadViewModel()
        {
            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
    }
}