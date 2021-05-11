//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/05/2552 03:39:03
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamresultlocks
		{
			#region Member 
			private	string accession_no;
			private	byte sl_no;
			private	string is_locked;
			private	int working_rad;
			private	int unlocked_by;
			private	DateTime unlocked_on;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
            private DateTime last_modified_on;
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
			public	byte SL_NO
			{
				get{ return sl_no;}
				set{ sl_no=value;}
			}
			public	string IS_LOCKED
			{
				get{ return is_locked;}
				set{ is_locked=value;}
			}
			public	int WORKING_RAD
			{
				get{ return working_rad;}
				set{ working_rad=value;}
			}
			public	int UNLOCKED_BY
			{
				get{ return unlocked_by;}
				set{ unlocked_by=value;}
			}
			public	DateTime UNLOCKED_ON
			{
				get{ return unlocked_on;}
				set{ unlocked_on=value;}
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


			#region Constructor 
			public RISExamresultlocks(){

			}
			#endregion 


			#region Method 
			public RISExamresultlocks Copy()
			{
				return MemberwiseClone() as RISExamresultlocks;
			}
			#endregion
		}
}

