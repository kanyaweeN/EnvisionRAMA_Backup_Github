using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_FINALIZEPRIVILEGE
    {
        public AC_FINALIZEPRIVILEGE()
        { 
        
        }

        public int FINALIZEPRIVILEGE_ID { get; set; }
        public int JOBTITLE_ID { get; set; }
        public int EXAM_ID { get; set; }
        public char IS_ACTIVE { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public int EXAM_TYPE { get; set; }
        public string MODE { get; set; }
        public int EMP_ID { get; set; }
    }
}
