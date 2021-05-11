//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISOrderdtl
		{
			#region Constructor 
			public RISOrderdtl(){

			}
			#endregion 


			#region Member 
			private	int order_id;
			private	int exam_id;
			private	string accession_no;
			private	byte q_no;
			private	int modality_id;
			private	DateTime exam_dt;
			private	int service_type;
            private int qty;
			private	int assigned_to;
			private	string hl7_text;
			private	string hl7_sent;
			private	decimal rate;
			private	string comments;
			private	string special_clinic;
			private	int image_captured_by;
			private	DateTime image_captured_on;
			private	int qa_by;
			private	DateTime qa_on;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private int old_exam_id;
            private string priority;
            private DateTime est_start_time;

            private int arrival_by;
            private DateTime arrival_on;
            private string self_arrival;
            private string is_deleted;
            private int clinic_type;
            private string status;
            private int bp_view;
        private string his_sync;
        private string his_ack;
        //EST_START_TIME
			#endregion 


			#region Property 
            public int ARRIVAL_BY
            {
                get { return arrival_by; }
                set { arrival_by = value; }
            }
            public string SELF_ARRIVAL
            {
                get { return self_arrival; }
                set { self_arrival = value; }
            }
            public DateTime ARRIVAL_ON
            {
                get { return arrival_on; }
                set { arrival_on = value; }
            }
            public DateTime EST_START_TIME
            {
                get { return est_start_time; }
                set { est_start_time = value; }
            }
			public	int ORDER_ID
			{
				get{ return order_id;}
				set{ order_id=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	byte Q_NO
			{
				get{ return q_no;}
				set{ q_no=value;}
			}
			public	int MODALITY_ID
			{
				get{ return modality_id;}
				set{ modality_id=value;}
			}
			public	DateTime EXAM_DT
			{
				get{ return exam_dt;}
				set{ exam_dt=value;}
			}
			public	int SERVICE_TYPE
			{
				get{ return service_type;}
				set{ service_type=value;}
			}
			public	int QTY
			{
				get{ return qty;}
				set{ qty=value;}
			}
			public	int ASSIGNED_TO
			{
				get{ return assigned_to;}
				set{ assigned_to=value;}
			}
			public	string HL7_TEXT
			{
				get{ return hl7_text;}
				set{ hl7_text=value;}
			}
			public	string HL7_SENT
			{
				get{ return hl7_sent;}
				set{ hl7_sent=value;}
			}
			public	decimal RATE
			{
				get{ return rate;}
				set{ rate=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
			}
			public	string SPECIAL_CLINIC
			{
				get{ return special_clinic;}
				set{ special_clinic=value;}
			}
			public	int IMAGE_CAPTURED_BY
			{
				get{ return image_captured_by;}
				set{ image_captured_by=value;}
			}
			public	DateTime IMAGE_CAPTURED_ON
			{
				get{ return image_captured_on;}
				set{ image_captured_on=value;}
			}
			public	int QA_BY
			{
				get{ return qa_by;}
				set{ qa_by=value;}
			}
			public	DateTime QA_ON
			{
				get{ return qa_on;}
				set{ qa_on=value;}
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
            public int OLD_EXAM_ID
        {
            get { return old_exam_id; }
            set { old_exam_id = value; }
        }
            public string PRIORITY
            {
                get { return priority; }
                set { priority = value; }
            }
            public string IS_DELETED {
            get { return is_deleted; }
            set { is_deleted = value; }
            }
            public int Clinic_type
            {
                get { return clinic_type; }
                set { clinic_type = value; }
            }
            public string STATUS
            {
                get { return status; }
                set { status=value; }
            }
        public int BV_VIEW
        {
            get { return bp_view; }
            set { bp_view = value; }
        }
        public string HIS_SYNC
        {
            get { return his_sync; }
            set { his_sync = value; }
        }
        public string HIS_ACK
        {
            get { return his_ack; }
            set { his_ack = value; }
        }
			#endregion 
		}
}

