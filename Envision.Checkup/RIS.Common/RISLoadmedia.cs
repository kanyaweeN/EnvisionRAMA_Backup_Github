//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:26
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISLoadmedia
		{
			#region Member 
			private	int load_id;
        private DateTime from_date;
        private DateTime to_date;
        private int selectcase;
        private int empid;
        private string accession;

			private	string hn;
			private	string visit_no;
			private	string admission_no;
			private	DateTime load_dt;
			private	DateTime load_start_time;
			private	string req_by;
			private	int req_unit;
			private	int req_doc;
			private	string media_type;
			private	string reason;
			private	string comment;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int LOAD_ID
			{
				get{ return load_id;}
				set{ load_id=value;}
			}
        public DateTime FROM_DATE
        {
            get { return from_date; }
            set { from_date = value; }
        }
        public DateTime TO_DATE
        {
            get { return to_date; }
            set { to_date = value; }
        }
        public int SELECTCASE
        {
            get { return selectcase; }
            set { selectcase = value; }
        }
        public int EMP_ID
        {
            get { return empid; }
            set { empid = value; }
        }
        public string ACCESSION_NO
        {
            get { return accession; }
            set { accession = value; }
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
			public	DateTime LOAD_DT
			{
				get{ return load_dt;}
				set{ load_dt=value;}
			}
			public	DateTime LOAD_START_TIME
			{
				get{ return load_start_time;}
				set{ load_start_time=value;}
			}
			public	string REQ_BY
			{
				get{ return req_by;}
				set{ req_by=value;}
			}
			public	int REQ_UNIT
			{
				get{ return req_unit;}
				set{ req_unit=value;}
			}
			public	int REQ_DOC
			{
				get{ return req_doc;}
				set{ req_doc=value;}
			}
			public	string MEDIA_TYPE
			{
				get{ return media_type;}
				set{ media_type=value;}
			}
			public	string REASON
			{
				get{ return reason;}
				set{ reason=value;}
			}
			public	string COMMENT
			{
				get{ return comment;}
				set{ comment=value;}
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
			#endregion 


			#region Constructor 
			public RISLoadmedia(){

			}
			#endregion 


			#region Method 
			public RISLoadmedia Copy()
			{
				return MemberwiseClone() as RISLoadmedia;
			}
			#endregion
		}
}

