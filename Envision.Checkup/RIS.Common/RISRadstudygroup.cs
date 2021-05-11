//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/04/2009 12:35:34
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISRadstudygroup
		{
			#region Member 
			private	int radiologist_id;
			private	string accession_no;
			private	bool is_favourite;
			private	bool is_teaching;
			private	bool is_others;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string mode;
			#endregion 


			#region Property 
			public	int RADIOLOGIST_ID
			{
				get{ return radiologist_id;}
				set{ radiologist_id=value;}
			}
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	bool IS_FAVOURITE
			{
				get{ return is_favourite;}
				set{ is_favourite=value;}
			}
			public	bool IS_TEACHING
			{
				get{ return is_teaching;}
				set{ is_teaching=value;}
			}
			public	bool IS_OTHERS
			{
				get{ return is_others;}
				set{ is_others=value;}
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
			#endregion 


			#region Constructor 
			public RISRadstudygroup(){

			}
			#endregion 


			#region Method 
			public RISRadstudygroup Copy()
			{
				return MemberwiseClone() as RISRadstudygroup;
			}
			#endregion
		}
}

