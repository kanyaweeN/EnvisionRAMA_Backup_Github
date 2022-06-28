using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_PRSTUDIES
    {
        public int STUDY_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public Byte ITERATION { get; set; }
        public int PR_ALGORITHM_ID { get; set; }
        public int PR_GROUP_ID { get; set; }
        public int RAD_ID { get; set; }
        public int RAD_OPINION { get; set; }
        public string IS_CLINICALLY_SIGNIFICANT { get; set; }
        public string RAD_COMMENTS { get; set; }
        public string QA_SCORE { get; set; }
        public int QA_BY { get; set; }
        public DateTime QA_ON { get; set; }
        public string PR_STATUS { get; set; }
        public int REPORT_LANG_ID { get; set; }
        public string REPORT_LANG_COMMENTS { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
