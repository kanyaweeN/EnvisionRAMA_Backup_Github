using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace Envision.Common
{
    public class DistributionNew
    {
        public int selectcase{get;set;}

        public DateTime datefrom { get; set; }
        public DateTime todate { get; set; }
        public string assignname { get; set; }
        public string accessionno { get; set; }
        public string hn { get; set; }
        public int assignedTo { get; set; }
        public int EMP_ID { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public string PRIORITY { get; set; }

    }
}
