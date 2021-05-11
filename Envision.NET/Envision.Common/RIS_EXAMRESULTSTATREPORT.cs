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
    public class RIS_EXAMRESULTSTATREPORT
    {
        public int ORDER_ID { get; set; }
        public int EXAM_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public int NOTE_NO { get; set; }
        public string NOTE_TEXT { get; set; }

        public System.Nullable<int> NOTE_BY { get; set; }
        public System.Nullable<System.DateTime> NOTE_ON { get; set; }
        public System.Nullable<int> ORG_ID { get; set; }
        public System.Nullable<int> CREATED_BY { get; set; }
        public System.Nullable<System.DateTime> CREATED_ON { get; set; }

        public System.Nullable<int> LAST_MODIFIED_BY { get; set; }
        public System.Nullable<System.DateTime> LAST_MODIFIED_ON { get; set; }
        public string NOTE_TEXT_RTF { get; set; }
        public string HL7_TEXT { get; set; }
        public string NOTE_TEXT_HTML { get; set; }
        public string NOTE_TEXT_RTFtoHTML { get; set; }

        public EntityRef<GBL_ENV> GBL_ENV { get; set; }
        public EntityRef<HR_EMP> HR_EMP { get; set; }
        public EntityRef<RIS_EXAMRESULT> RIS_EXAMRESULT { get; set; }

        public RIS_EXAMRESULTSTATREPORT()
        {
            this.GBL_ENV = default(EntityRef<GBL_ENV>);
            this.HR_EMP = default(EntityRef<HR_EMP>);
            this.RIS_EXAMRESULT = default(EntityRef<RIS_EXAMRESULT>);
        }
    }
}
