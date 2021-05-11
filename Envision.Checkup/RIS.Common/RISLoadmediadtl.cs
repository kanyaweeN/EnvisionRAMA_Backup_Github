//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISLoadmediadtl
		{
			#region Member 
			private	int load_id;
			private	int exam_id;
        private int selectcase;
			private	string accession_no;
			private	DateTime exam_dt;
			private	string hl7_text;
			private	string hl7_sent;
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
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
        public int SELECTCASE
        {
            get { return selectcase; }
            set { selectcase = value; }
        }
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	DateTime EXAM_DT
			{
				get{ return exam_dt;}
				set{ exam_dt=value;}
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
			public RISLoadmediadtl(){

			}
			#endregion 


			#region Method 
			public RISLoadmediadtl Copy()
			{
				return MemberwiseClone() as RISLoadmediadtl;
			}
			#endregion
		}
}

