using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_STUDYLIBRARY
    {
        public int RADIOLOGIST_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        public bool IS_FAVOURITE { get; set; }
        public bool IS_TEACHING { get; set; }
        public bool IS_RESEARCH { get; set; }
        public bool IS_OTHERS { get; set; }
        public string TAGS { get; set; }
        public char LEVEL { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
        
        public bool IS_DELETED { get; set; }

        public int ACR_ID { get; set; }
        public int EXAM_SKILL_ID { get; set; }
        public int CPT_ID { get; set; }
        public int ICD_ID { get; set; }
        public int EMP_ID { get; set; }

        public string MODE { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public string HN { get; set; }
        public string DIFFICULTY_LEVEL { get; set; }

        public string SUMMARY_ACR { get; set; }
        public string SUMMARY_BODYPART { get; set; }
        public string SUMMARY_CPT { get; set; }
        public string SUMMARY_ICD { get; set; }
        public string SUMMARY_SHARED_WITH { get; set; }

        public char SHARE_TYPE { get; set; }

        public DateTime CONFERENCE_DATE { get; set; }
        public int CONFERENCE_ID { get; set; }
        public int LIBRARY_CONFERENCE_ID { get; set; }
        public RIS_STUDYLIBRARY()
        { 
        
        }
    }
}
