using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MSPowerInfo
{
    public class NewsLetterInfo

    {

        public int NewsLetter_Id { get; set; }

        public int Language_Id { get; set; }

        public string NewsLetter_Title { get; set; }

        [AllowHtml]

        public string NewsLetter_Description { get; set; }

        public DateTime NewLetter_Release_Date { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

    }
}
