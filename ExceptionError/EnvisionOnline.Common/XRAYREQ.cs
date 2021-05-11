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
    public class XRAYREQ
    {
        public int ORDER_ID { get; set; }
        public string REQUESTNO { get; set; }
        public string FACILITYRMSNO { get; set; }
        public string HN { get; set; }
        public string FULLNAME { get; set; }
        public DateTime ORDER_DT { get; set; }
        public string INSURANCE_TYPE_ID { get; set; }
        public DateTime ORDER_START_TIME { get; set; }
        public DateTime REQUEST_DATE { get; set; }
        public string REF_UNIT { get; set; }
        public string EMP_UID { get; set; }
        public string DOCNAME { get; set; }
        public string PAT_STATUS { get; set; }
        public string REF_DOC_INSTRUCTION { get; set; }
        public string CLINICAL_INSTRUCTION { get; set; }
        public string STATUS { get; set; }
        public string REF_DOC_TITLE { get; set; }
        public string REF_DOC_FNAME { get; set; }
        public string REF_DOC_LNAME { get; set; }
        public string REF_DOC_ID { get; set; }
        public string IS_CANCELED { get; set; }
        public int ORG_ID { get; set; }
        public int REG_ID { get; set; }
        public string ENC_CLINIC { get; set; }
        public int ENC_ID { get; set; }
        public string ENC_TYPE { get; set; }


        public int EXAM_ID { get; set; }
        public string EXAM_UID { get; set; }
        public int MODALITY_ID { get; set; }
        public DateTime EXAM_DT { get; set; }
        public string PRIORITY { get; set; }
        public int ASSIGN_TO { get; set; }
        public string ASSIGN_TO_TITLE { get; set; }
        public string ASSIGN_TO_FNAME { get; set; }
        public string ASSIGN_TO_LNAME { get; set; }
        public string ASSIGN_TO_UID { get; set; }
        public int QTY { get; set; }
        public decimal RATE { get; set; }
        public int CLINIC_TYPE { get; set; }
        public int BPVIEW_ID { get; set; }
        public string BP_VIEW { get; set; }
        public string HIS_SYNC { get; set; }
        public string HIS_ACK { get; set; }
        public int PREPARATION_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public string IS_DELETED { get; set; }
        public string COMMENTS { get; set; }

        public int S_XSEQ { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public int PAT_DEST_ID { get; set; }

        public string IS_PORTABLE { get; set; }
        public string REASON { get; set; }
    }
}

