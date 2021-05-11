//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    25/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISQaworks
		{
			#region Constructor 
			public RISQaworks(){

			}
			#endregion 


			#region Member 
			private	string accession_no;
			private	byte sl;
			private	string qa_result;
			private	string comments;
			private	DateTime start_time;
			private	DateTime end_time;
			private	int no_of_images_print;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string mode;
            private DateTime from_date;
            private DateTime to_date;
			#endregion 


			#region Property 
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	byte SL
			{
				get{ return sl;}
				set{ sl=value;}
			}
			public	string QA_RESULT
			{
				get{ return qa_result;}
				set{ qa_result=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
			}
			public	DateTime START_TIME
			{
				get{ return start_time;}
				set{ start_time=value;}
			}
			public	DateTime END_TIME
			{
				get{ return end_time;}
				set{ end_time=value;}
			}
			public	int NO_OF_IMAGES_PRINT
			{
				get{ return no_of_images_print;}
				set{ no_of_images_print=value;}
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
            public string MODE
            {
                get { return mode; }
                set { mode = value; }
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
			#endregion 
		}
}

