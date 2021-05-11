//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    26/03/2551
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RIS.Common
{
	public class RISExam
		{
			#region Constructor 
			public RISExam(){

			}
			#endregion 


			#region Member 
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
			private	string stat_flag;
			private	string urgent_flag;
			private	byte release_auth_level;
			private	byte finalize_auth_level;
			private	string preparation_flag;
			private	decimal preparation_tat;
			private	string repeat_flag;
			private	int icd_id;
			private	int acr_id;
			private	int cpt_id;
			private	byte def_capture;
			private	byte? def_images;
			private	string is_structured_report;
			private	string qa_required;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	string created_by;
			private	DateTime created_on;
			private	string last_modified_by;
			private	DateTime last_modified_on;
            private int? bp_id;
        private decimal vip_rate;
        private string is_checkup;
			#endregion 


			#region Property 
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
			public	string STAT_FLAG
			{
				get{ return stat_flag;}
				set{ stat_flag=value;}
			}
			public	string URGENT_FLAG
			{
				get{ return urgent_flag;}
				set{ urgent_flag=value;}
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
			public	byte? DEF_IMAGES
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
            public int? BP_ID
            {
                get { return bp_id; }
                set { bp_id = value; }
            }
        public decimal VIP_RATE
        {
            get { return vip_rate; }
            set { vip_rate = value; }
        }
        public string IS_CHECKUP
        {
            get { return is_checkup; }
            set { is_checkup = value; }
        }
			#endregion 

        }

            #region collections
        public class ExamObjectCollection : CollectionBase
        {
            public void Add(RISExam _examObject)
            {
                this.List.Add(_examObject);
            }
            public void Delete(int index)
            {
                this.List.RemoveAt(index);
            }
            public RISExam this[int index]
            {
                get
                {
                    return (RISExam)List[index];
                }
                set
                {
                    List[index] = value;
                }
            }
        }
            #endregion

}

