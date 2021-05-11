//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:28
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISQareason
		{
			#region Member 
			private	int reason_id;
			private	string reason_uid;
			private	string reason_text;
			private	string reason_action;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int REASON_ID
			{
				get{ return reason_id;}
				set{ reason_id=value;}
			}
			public	string REASON_UID
			{
				get{ return reason_uid;}
				set{ reason_uid=value;}
			}
			public	string REASON_TEXT
			{
				get{ return reason_text;}
				set{ reason_text=value;}
			}
			public	string REASON_ACTION
			{
				get{ return reason_action;}
				set{ reason_action=value;}
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
			#endregion 


			#region Constructor 
			public RISQareason(){

			}
			#endregion 


			#region Method 
			public RISQareason Copy()
			{
				return MemberwiseClone() as RISQareason;
			}
			#endregion
		}
}

