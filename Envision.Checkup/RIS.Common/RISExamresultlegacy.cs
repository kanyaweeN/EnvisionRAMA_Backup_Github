//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    24/04/2009 01:28:07
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamresultlegacy
		{
		#region Member 
		private	int examresultlegacy_id;
        private string hn;
		private	string accession_no;
		private	string order_uid;
		private	string exam_uid;
		private	string result_text_html;
		private	string result_status;
		private	string released_by;
		private	DateTime released_on;
		private	string finalized_by;
		private	DateTime finalized_on;
		private	string created_by;
		private	DateTime created_on;

        private int mode;
        private int emp_id;
        private DateTime fromdate;
        private DateTime todate;
        
			#endregion 


			#region Property 
		public	int EXAMRESULTLEGACY_ID
		{
			get{ return examresultlegacy_id;}
			set{ examresultlegacy_id=value;}
		}
        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
		public	string ACCESSION_NO
		{
			get{ return accession_no;}
			set{ accession_no=value;}
		}
		public	string ORDER_UID
		{
			get{ return order_uid;}
			set{ order_uid=value;}
		}
		public	string EXAM_UID
		{
			get{ return exam_uid;}
			set{ exam_uid=value;}
		}
		public	string RESULT_TEXT_HTML
		{
			get{ return result_text_html;}
			set{ result_text_html=value;}
		}
		public	string RESULT_STATUS
		{
			get{ return result_status;}
			set{ result_status=value;}
		}
		public	string RELEASED_BY
		{
			get{ return released_by;}
			set{ released_by=value;}
		}
		public	DateTime RELEASED_ON
		{
			get{ return released_on;}
			set{ released_on=value;}
		}
		public	string FINALIZED_BY
		{
			get{ return finalized_by;}
			set{ finalized_by=value;}
		}
		public	DateTime FINALIZED_ON
		{
			get{ return finalized_on;}
			set{ finalized_on=value;}
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
        public DateTime FROM_DATE
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        public DateTime TO_DATE
        {
            get { return todate; }
            set { todate = value; }
        }
			#endregion 


			#region Constructor 
			public RISExamresultlegacy(){

			}
			#endregion 


			#region Method 
			public RISExamresultlegacy Copy()
			{
				return MemberwiseClone() as RISExamresultlegacy;
			}
			#endregion
		}
}

