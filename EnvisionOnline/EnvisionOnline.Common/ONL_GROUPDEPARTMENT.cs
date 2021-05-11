using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class ONL_GROUPDEPARTMENT
    {
        public int GDEPT_ID { get; set; }
        public string GDEPT_TEXT { get; set; }
        public string GDEPT_TYPE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
