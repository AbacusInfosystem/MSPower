using MSPowerWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSPowerWebApp.Models
{
    public class ImageUploadViewModel
    {

        //Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public List<string> Images = new List<string>();

        public ImageUploadViewModel()
        {
            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

    }
}