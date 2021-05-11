//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/06/2009 02:20:56
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamlog
		{
			#region Member 
			private	int log_id;
			private	DateTime effective_dt;
			private	byte[] start_lsn;
			private	byte[] seqval;
			private	int operation;
			private	byte[] update_mask;
			private	int exam_id;
			private	string exam_uid;
			private	string govt_id;
			private	string exam_name;
			private	string report_header;
			private	string req_sample;
			private	decimal rate;
			private	decimal govt_rate;
			private	int exam_type;
			private	string service_type;
			private	decimal claimable_amt;
			private	decimal nonclaimable_amt;
			private	decimal free_amt;
			private	string special_clinic;
			private	decimal special_rate;
			private	string vat_applicable;
			private	decimal vat_rate;
			private	int unit_id;
			private	int rev_head_id;
			private	string is_active;
			private	decimal avg_req_hrs;
			private	decimal min_req_hrs;
			private	decimal cost_price;
			private	byte release_auth_level;
			private	byte finalize_auth_level;
			private	string preparation_flag;
			private	decimal preparation_tat;
			private	string repeat_flag;
			private	int icd_id;
			private	int acr_id;
			private	int cpt_id;
			private	byte def_capture;
			private	byte def_images;
			private	string is_structured_report;
			private	string qa_required;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	string created_by;
			private	DateTime created_on;
			private	string last_modified_by;
			private	DateTime last_modified_on;
			private	int bp_id;
			private	bool stat_possible;
			private	byte stat_tat_min;
			private	bool urgent_possible;
			private	byte urgent_tat_min;
			private	string defer_his_reconcile;
			private	string is_checkup;
			private	decimal vip_rate;
            private DateTime fromdate;
            private DateTime todate;
			#endregion 


			#region Property 
			public	int LOG_ID
			{
				get{ return log_id;}
				set{ log_id=value;}
			}
			public	DateTime EFFECTIVE_DT
			{
				get{ return effective_dt;}
				set{ effective_dt=value;}
			}
			public	byte[] START_LSN
			{
				get{ return start_lsn;}
				set{ start_lsn=value;}
			}
			public	byte[] SEQVAL
			{
				get{ return seqval;}
				set{ seqval=value;}
			}
			public	int OPERATION
			{
				get{ return operation;}
				set{ operation=value;}
			}
			public	byte[] UPDATE_MASK
			{
				get{ return update_mask;}
				set{ update_mask=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	string EXAM_UID
			{
				get{ return exam_uid;}
				set{ exam_uid=value;}
			}
			public	string GOVT_ID
			{
				get{ return govt_id;}
				set{ govt_id=value;}
			}
			public	string EXAM_NAME
			{
				get{ return exam_name;}
				set{ exam_name=value;}
			}
			public	string REPORT_HEADER
			{
				get{ return report_header;}
				set{ report_header=value;}
			}
			public	string REQ_SAMPLE
			{
				get{ return req_sample;}
				set{ req_sample=value;}
			}
			public	decimal RATE
			{
				get{ return rate;}
				set{ rate=value;}
			}
			public	decimal GOVT_RATE
			{
				get{ return govt_rate;}
				set{ govt_rate=value;}
			}
			public	int EXAM_TYPE
			{
				get{ return exam_type;}
				set{ exam_type=value;}
			}
			public	string SERVICE_TYPE
			{
				get{ return service_type;}
				set{ service_type=value;}
			}
			public	decimal CLAIMABLE_AMT
			{
				get{ return claimable_amt;}
				set{ claimable_amt=value;}
			}
			public	decimal NONCLAIMABLE_AMT
			{
				get{ return nonclaimable_amt;}
				set{ nonclaimable_amt=value;}
			}
			public	decimal FREE_AMT
			{
				get{ return free_amt;}
				set{ free_amt=value;}
			}
			public	string SPECIAL_CLINIC
			{
				get{ return special_clinic;}
				set{ special_clinic=value;}
			}
			public	decimal SPECIAL_RATE
			{
				get{ return special_rate;}
				set{ special_rate=value;}
			}
			public	string VAT_APPLICABLE
			{
				get{ return vat_applicable;}
				set{ vat_applicable=value;}
			}
			public	decimal VAT_RATE
			{
				get{ return vat_rate;}
				set{ vat_rate=value;}
			}
			public	int UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
			}
			public	int REV_HEAD_ID
			{
				get{ return rev_head_id;}
				set{ rev_head_id=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
			}
			public	decimal AVG_REQ_HRS
			{
				get{ return avg_req_hrs;}
				set{ avg_req_hrs=value;}
			}
			public	decimal MIN_REQ_HRS
			{
				get{ return min_req_hrs;}
				set{ min_req_hrs=value;}
			}
			public	decimal COST_PRICE
			{
				get{ return cost_price;}
				set{ cost_price=value;}
			}
			public	byte RELEASE_AUTH_LEVEL
			{
				get{ return release_auth_level;}
				set{ release_auth_level=value;}
			}
			public	byte FINALIZE_AUTH_LEVEL
			{
				get{ return finalize_auth_level;}
				set{ finalize_auth_level=value;}
			}
			public	string PREPARATION_FLAG
			{
				get{ return preparation_flag;}
				set{ preparation_flag=value;}
			}
			public	decimal PREPARATION_TAT
			{
				get{ return preparation_tat;}
				set{ preparation_tat=value;}
			}
			public	string REPEAT_FLAG
			{
				get{ return repeat_flag;}
				set{ repeat_flag=value;}
			}
			public	int ICD_ID
			{
				get{ return icd_id;}
				set{ icd_id=value;}
			}
			public	int ACR_ID
			{
				get{ return acr_id;}
				set{ acr_id=value;}
			}
			public	int CPT_ID
			{
				get{ return cpt_id;}
				set{ cpt_id=value;}
			}
			public	byte DEF_CAPTURE
			{
				get{ return def_capture;}
				set{ def_capture=value;}
			}
			public	byte DEF_IMAGES
			{
				get{ return def_images;}
				set{ def_images=value;}
			}
			public	string IS_STRUCTURED_REPORT
			{
				get{ return is_structured_report;}
				set{ is_structured_report=value;}
			}
			public	string QA_REQUIRED
			{
				get{ return qa_required;}
				set{ qa_required=value;}
			}
			public	string IS_UPDATED
			{
				get{ return is_updated;}
				set{ is_updated=value;}
			}
			public	string IS_DELETED
			{
				get{ return is_deleted;}
				set{ is_deleted=value;}
			}
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
			}
			public	string CREATED_BY
			{
				get{ return created_by;}
				set{ created_by=value;}
			}
			public	DateTime CREATED_ON
			{
				get{ return created_on;}
				set{ created_on=value;}
			}
			public	string LAST_MODIFIED_BY
			{
				get{ return last_modified_by;}
				set{ last_modified_by=value;}
			}
			public	DateTime LAST_MODIFIED_ON
			{
				get{ return last_modified_on;}
				set{ last_modified_on=value;}
			}
			public	int BP_ID
			{
				get{ return bp_id;}
				set{ bp_id=value;}
			}
			public	bool STAT_POSSIBLE
			{
				get{ return stat_possible;}
				set{ stat_possible=value;}
			}
			public	byte STAT_TAT_MIN
			{
				get{ return stat_tat_min;}
				set{ stat_tat_min=value;}
			}
			public	bool URGENT_POSSIBLE
			{
				get{ return urgent_possible;}
				set{ urgent_possible=value;}
			}
			public	byte URGENT_TAT_MIN
			{
				get{ return urgent_tat_min;}
				set{ urgent_tat_min=value;}
			}
			public	string DEFER_HIS_RECONCILE
			{
				get{ return defer_his_reconcile;}
				set{ defer_his_reconcile=value;}
			}
			public	string IS_CHECKUP
			{
				get{ return is_checkup;}
				set{ is_checkup=value;}
			}
			public	decimal VIP_RATE
			{
				get{ return vip_rate;}
				set{ vip_rate=value;}
			}
        public DateTime FROMDATE
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        public DateTime TODATE
        {
            get { return todate; }
            set { todate = value; }
        }
			#endregion 


			#region Constructor 
			public RISExamlog(){

			}
			#endregion 


			#region Method 
			public RISExamlog Copy()
			{
				return MemberwiseClone() as RISExamlog;
			}
			#endregion
		}
}

