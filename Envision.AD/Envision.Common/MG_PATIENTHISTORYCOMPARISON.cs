using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class MG_PATIENTHISTORYCOMPARISON
    {
        public int COMPARISON_ID { get; set; }
        public int REG_ID { get; set; }
        public int COMPARED_BY { get; set; }
        public string COMPARED_TYPE { get; set; }
        public DateTime COMPARED_ON { get; set; }
        public string COMPARING_EXAM { get; set; }
        public string COMPARED_WITH { get; set; }
        public string COMPARED_TEXT { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public int LAST_MODIFIED_BY { get; set; }
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
