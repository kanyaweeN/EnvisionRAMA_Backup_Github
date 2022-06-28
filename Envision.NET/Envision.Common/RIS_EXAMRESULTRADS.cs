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
    public class RIS_EXAMRESULTRADS
    {
        public string ACCESSION_NO { get; set; }
        public int RAD_ID { get; set; }
        public bool CAN_PRELIM { get; set; }
        public bool CAN_FINALIZE { get; set; }
        public byte SL_NO { get; set; }
        public int ORG_ID { get; set;}
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public string MODE { get; set; }
        public string IS_SHOW_PACS { get; set; }
    }
}
