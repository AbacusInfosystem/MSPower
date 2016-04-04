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

        public ImageUploadViewModel()
        {
            File_Name = new List<string>();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }

        public List<string> File_Name { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

    }
}