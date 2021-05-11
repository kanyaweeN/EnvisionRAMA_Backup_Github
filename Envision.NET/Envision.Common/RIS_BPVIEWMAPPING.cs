using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_BPVIEWMAPPING
    {
        public int EXAM_ID{get;set;}
        public int BPVIEW_ID{get;set;}
        public int CREATED_BY{get;set;}
        public DateTime CREATED_ON {get;set;}
        public int LAST_MODIFIED_BY {get;set;}
        public DateTime LAST_MODIFIED_ON {get;set;}
        public string NEED_DETAIL{get;set;}
        public byte SL_NO { get; set; }
    }
}
