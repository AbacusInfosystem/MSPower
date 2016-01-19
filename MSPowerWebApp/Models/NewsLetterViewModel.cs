using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MSPowerInfo;
using MSPowerWebApp.Common;

namespace MSPowerWebApp.Models
{
    public class NewsLetterViewModel
    {
        public NewsLetterInfo NewsLetter { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<NewsLetterInfo> NewsLetters { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public NewsLetter_Filter Filter { get; set; }

        public HttpPostedFileBase Upload_File { get; set; }

        public bool Is_PDF_Exists { get; set; }

        public NewsLetterViewModel()
        {
            NewsLetter = new NewsLetterInfo();

            Pager = new PaginationInfo();

            NewsLetters = new List<NewsLetterInfo>();

            Friendly_Message = new List<FriendlyMessageInfo>();
        }

    }

    public class NewsLetter_Filter
    {
        public int NewsLetter_Id { get; set; }
    }
}