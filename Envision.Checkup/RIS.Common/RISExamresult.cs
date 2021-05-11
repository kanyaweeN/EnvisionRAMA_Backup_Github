//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    26/03/2552 02:07:31
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamresult
		{
			#region Member 
			private	string accession_no;
			private	int order_id;
			private	int exam_id;
			private	string result_text_html;
			private	string result_text_plain;
			private	string result_text_rtf;
			private	byte[] result_binary;
			private	string result_status;
			private	int icd_id;
			private	string hl7_text;
			private	string hl7_send;
			private	int released_by;
			private	DateTime released_on;
			private	int finalized_by;
			private	DateTime finalized_on;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private DateTime dtFrom;
            private DateTime dtEnd;
            private int mode;
            private int emp_id;
            private string hn;
            private string status;
            private string merge;
            private string mergewith;
            private int severity_id;
			#endregion 


			#region Property 
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
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
			public	string RESULT_TEXT_HTML
			{
				get{ return result_text_html;}
				set{ result_text_html=value;}
			}
			public	string RESULT_TEXT_PLAIN
			{
				get{ return result_text_plain;}
				set{ result_text_plain=value;}
			}
			public	string RESULT_TEXT_RTF
			{
				get{ return result_text_rtf;}
				set{ result_text_rtf=value;}
			}
			public	byte[] RESULT_BINARY
			{
				get{ return result_binary;}
				set{ result_binary=value;}
			}
			public	string RESULT_STATUS
			{
				get{ return result_status;}
				set{ result_status=value;}
			}
			public	int ICD_ID
			{
				get{ return icd_id;}
				set{ icd_id=value;}
			}
			public	string HL7_TEXT
			{
				get{ return hl7_text;}
				set{ hl7_text=value;}
			}
			public	string HL7_SEND
			{
				get{ return hl7_send;}
				set{ hl7_send=value;}
			}
			public	int RELEASED_BY
			{
				get{ return released_by;}
				set{ released_by=value;}
			}
			public	DateTime RELEASED_ON
			{
				get{ return released_on;}
				set{ released_on=value;}
			}
			public	int FINALIZED_BY
			{
				get{ return finalized_by;}
				set{ finalized_by=value;}
			}
			public	DateTime FINALIZED_ON
			{
				get{ return finalized_on;}
				set{ finalized_on=value;}
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
            public DateTime DATETIME_FROM {
            get { return dtFrom; }
            set { dtFrom = value; }
        }
            public DateTime DATETIME_END
        {
            get { return dtEnd; }
            set { dtEnd = value; }
        }
            public int MODE
        {
            get { return mode; }
            set { mode = value; }
        }
            public int EMP_ID
            {
                get { return emp_id; }
                set { emp_id = value; }
            }
            public string HN {
                get { return hn; }
                set { hn = value; }
            }
            public string STATUS {
                get { return status; }
                set { status = value; }
            }
            public string MERGE {
                get { return merge; }
                set { merge = value; }
            }
            public string MERGE_WITH {
                get { return mergewith; }
                set { mergewith = value; }
            }
        public int SEVERITY_ID
        {
            get { return severity_id; }
            set { severity_id = value; }
        }
			#endregion 


			#region Constructor 
			public RISExamresult(){

			}
			#endregion 


			#region Method 
			public RISExamresult Copy()
			{
				return MemberwiseClone() as RISExamresult;
			}
			#endregion
		}
}

