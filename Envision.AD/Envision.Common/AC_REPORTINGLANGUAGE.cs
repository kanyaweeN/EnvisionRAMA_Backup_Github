﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_REPORTINGLANGUAGE
    {
      public int REPORT_LANG_ID { get;set;}
      public string REPORT_LANG_LABEL { get;set;}
      public string REPORT_LANG_VALUE { get;set;}
      public int ORG_ID { get;set;}
      public int CREATED_BY { get;set;}
      public DateTime CREATED_ON { get;set;}
      public int LAST_MODIFIED_BY { get;set;}
      public DateTime LAST_MODIFIED_ON { get; set; }
      public string SEND_MESSAGE { get; set; }
    }
}
