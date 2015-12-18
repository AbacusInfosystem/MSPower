using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerInfo
{
    class NewsLetterInfo

    {

        public int News_Letter_Id { get; set; }

        public int Language_Id { get; set; }

        public string News_Letter_Title { get; set; }

        public string News_Letter_Description { get; set; }

        public DateTime New_Letter_Release_Date { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }

    }
}
