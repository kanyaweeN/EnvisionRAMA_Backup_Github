using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class XRAYREQDTL
    {
        public XRAYREQDTL()
        { 
        }

        public int ORDER_ID { get; set;}
	    public int EXAM_ID { get; set;}
	    public string EXAM_UID { get; set;}
	    public int MODALITY_ID { get; set;}
	    public DateTime EXAM_DT { get; set;}
	    public string PRIORITY { get; set;}
	    public string STATUS { get; set;}
	    public int ASSIGN_TO { get; set;}
	    public string ASSIGN_TO_TITLE { get; set;}
	    public string ASSIGN_TO_FNAME { get; set;}
	    public string ASSIGN_TO_LNAME { get; set;}
	    public string ASSIGN_TO_UID { get; set;}
	    public DateTime CREATED_ON { get; set;}
	    public int QTY { get; set;}
	    public decimal RATE { get; set;}
	    public int CLINIC_TYPE { get; set;}
	    public string BP_VIEW { get; set;}
	    public string HIS_SYNC { get; set;}
	    public string HIS_ACK { get; set;}
	    public int PREPARATION_ID { get; set;}
	    public string ACCESSION_NO { get; set;}
	    public string IS_DELETED { get; set;}
	    public int LAST_MODIFIED_BY { get; set;}
	    public DateTime LAST_MODIFIED_ON { get; set;}
	    public string COMMENTS { get; set;}
	    public int CREATED_BY { get; set;}
	    public int ORG_ID { get; set;}
	    public int BPVIEW_ID { get; set;}
	    public int PAT_DEST_ID { get; set;}
	    public string IS_PORTABLE { get; set;}
        public string REASON { get; set; }
    }
}
