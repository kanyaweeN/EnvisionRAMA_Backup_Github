

using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common 
{
	public class RISOrder
		{
			#region Constructor 
			public RISOrder(){

			}
			#endregion 


			#region Member 
			private	int order_id;
			private	int reg_id;
			private	string hn;
			private	string visit_no;
			private	string admission_no;
			private	DateTime order_dt;
			private	int schedule_id;
			private	DateTime order_start_time;
			private	int ref_unit;
			private	int ref_doc;
			private	string ref_doc_instruction;
			private	string clinical_instruction;
			private	string reason;
			private	string diagnosis;
			private	int icd_id;
            private int arrival_by;
            private DateTime arrival_on;
            private string self_arrival;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private int insurance_type_id;//INSURANCE_TYPE_UID
            private string pat_status;
            private string is_cancel;
            private DateTime lmp_dt;

          
			#endregion 


			#region Property 
			public	int ORDER_ID
			{
				get{ return order_id;}
				set{ order_id=value;}
			}
			public	int REG_ID
			{
				get{ return reg_id;}
				set{ reg_id=value;}
			}
			public	string HN
			{
				get{ return hn;}
				set{ hn=value;}
			}
			public	string VISIT_NO
			{
				get{ return visit_no;}
				set{ visit_no=value;}
			}
			public	string ADMISSION_NO
			{
				get{ return admission_no;}
				set{ admission_no=value;}
			}
			public	DateTime ORDER_DT
			{
				get{ return order_dt;}
				set{ order_dt=value;}
			}
			public	int SCHEDULE_ID
			{
				get{ return schedule_id;}
				set{ schedule_id=value;}
			}
			public	DateTime ORDER_START_TIME
			{
				get{ return order_start_time;}
				set{ order_start_time=value;}
			}
			public	int REF_UNIT
			{
				get{ return ref_unit;}
				set{ ref_unit=value;}
			}
			public	int REF_DOC
			{
				get{ return ref_doc;}
				set{ ref_doc=value;}
			}
			public	string REF_DOC_INSTRUCTION
			{
				get{ return ref_doc_instruction;}
				set{ ref_doc_instruction=value;}
			}
			public	string CLINICAL_INSTRUCTION
			{
				get{ return clinical_instruction;}
				set{ clinical_instruction=value;}
			}
			public	string REASON
			{
				get{ return reason;}
				set{ reason=value;}
			}
			public	string DIAGNOSIS
			{
				get{ return diagnosis;}
				set{ diagnosis=value;}
			}
			public	int ICD_ID
			{
				get{ return icd_id;}
				set{ icd_id=value;}
			}
            public int ARRIVAL_BY
            {
                get { return arrival_by; }
                set { arrival_by = value; }
            }
            public DateTime ARRIVAL_ON
            {
                get { return arrival_on; }
                set { arrival_on = value; }
            }
            public string SELF_ARRIVAL
            {
                get { return self_arrival; }
                set { self_arrival = value; }
            }
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
			}
			public	int CREATED_BY
			{
				get{ return created_by;}
				set{ created_by=value;}
			}
			public	DateTime CREATED_ON
			{
				get{ return created_on;}
				set{ created_on=value;}
			}
			public	int LAST_MODIFIED_BY
			{
				get{ return last_modified_by;}
				set{ last_modified_by=value;}
			}
			public	DateTime LAST_MODIFIED_ON
			{
				get{ return last_modified_on;}
				set{ last_modified_on=value;}
			}
            public int INSURANCE_TYPE_ID
            {
                get { return insurance_type_id; }
                set { insurance_type_id = value; }
            }
            public string PAT_STATUS
            {
                get { return pat_status; }
                set { pat_status = value; }
            }
            public string IS_CANCELED {
                get { return is_cancel; }
                set { is_cancel = value; }
            }
            public DateTime Lmp_DT
            {
                get { return lmp_dt; }
                set { lmp_dt = value; }
            }
			#endregion 
		}
}

