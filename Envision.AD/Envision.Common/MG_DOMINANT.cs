using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class MG_DOMINANT
    {
        public int DOMINATE_CYST_ID { get; set; }
        public string ACCESSION_NO { get; set; }
        //public int BREAST_MARKDTL_ID { get; set; }
        public int MASS_NO { get; set; }
        public int DIAMETER { get; set; }
        public int CLOCK_LOCATION { get; set; }
        public string SIDE { get; set; }
        public string IS_DOMINANT_CYST { get; set; }
        public int ORG_ID { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
	    public int LAST_MODIFIED_BY 	{get;set;}
        public DateTime LAST_MODIFIED_ON { get; set; }
    }
}
