using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{
    [Table(Name = "dbo.RIS_BPVIEWMAPPING")]
    public partial class RIS_BPVIEWMAPPING 
    {
        int EXAM_ID {get;set;}

        int BPVIEW_ID { get; set; }

        int CREATED_BY{get;set;}

        DateTime CREATED_ON { get; set; }

        int LAST_MODIFIED_BY { get; set; }

        DateTime LAST_MODIFIED_ON { get; set; }
    }
}



