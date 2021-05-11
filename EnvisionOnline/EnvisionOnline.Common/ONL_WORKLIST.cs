using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnvisionOnline.Common
{
    public class ONL_WORKLIST
    {
        public int MODE { get; set; }
        public string HN { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string MODE_STR{get;set;}
        public int EMP_ID {get;set;}
        public string USER_NAME{get;set;}
        public int UNIT_ID{get;set;}
        public int AUTH_LEVEL_ID{get;set;}
        public string UNIT_ALIAS { get; set; }
    }
}
