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
    public class HL7Monitoring
    {
        public int SpType { get; set; }

        public string MsgType { get; set; }

        public int OrgID { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }



        public string PatientID { get; set; }

        public int OrderID { get; set; }
        public string AccessionNo { get; set; }

        public int ExamID { get; set; }

        public string OriginalStatus { get; set; }
        public string ChangeStatus { get; set; }

        public int RequestBy { get; set; }

        public string ChangePC { get; set; }

        public int CreatedBy { get; set; }

        public string Hl7Text { get; set; }
        public string Reason { get; set; }
    }
}
