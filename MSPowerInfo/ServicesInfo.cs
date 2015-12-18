using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPowerInfo
{
    public class ServicesInfo
    {

        public int Services_Id { get; set; }

        public int Language_Id { get; set; }

        public string Services_Title { get; set; }

        public string Services_Description { get; set; }

        public bool Is_Active { get; set; }

        public DateTime Created_On { get; set; }

        public int Created_By { get; set; }

        public DateTime Updated_On { get; set; }

        public int Updated_By { get; set; }
    }
}
