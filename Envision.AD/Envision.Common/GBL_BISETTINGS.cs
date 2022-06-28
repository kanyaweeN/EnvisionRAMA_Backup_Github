using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class GBL_BISETTINGS
    {
        public GBL_BISETTINGS()
        {
        }

        //@EMP_ID int
        //,@BI_NAME nvarchar(150)
        //,@BI_DESC nvarchar(300)
        //,@BI_TAG nvarchar(300)
        //,@IS_GLOBAL nvarchar(1)
        //,@ORG_ID int
        //,@CREATED_BY int

        public string MODE { get; set; }
        public int EMP_ID { get; set; }

        public string BI_NAME { get; set; }
        public string BI_DESC { get; set; }
        public string BI_TAG { get; set; }
        public char IS_GLOBAL { get; set; }
        public string BI_FIELD_ORDER { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public int LAST_MODIFIED_BY { get; set; }

        public int BISETTINGS_ID { get; set; }

    }
}
