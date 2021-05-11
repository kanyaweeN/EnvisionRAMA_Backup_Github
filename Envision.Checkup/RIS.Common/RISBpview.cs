//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    31/03/2552 02:52:49
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISBpview
		{
			#region Constructor 
			public RISBpview(){

			}
			#endregion 


			#region Member 
			private	int bpview_id;
			private	string bpview_uid;
			private	string bpview_name;
			private	string bpview_desc;
			private	byte no_of_exam;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int BPVIEW_ID
			{
				get{ return bpview_id;}
				set{ bpview_id=value;}
			}
			public	string BPVIEW_UID
			{
				get{ return bpview_uid;}
				set{ bpview_uid=value;}
			}
			public	string BPVIEW_NAME
			{
				get{ return bpview_name;}
				set{ bpview_name=value;}
			}
			public	string BPVIEW_DESC
			{
				get{ return bpview_desc;}
				set{ bpview_desc=value;}
			}
			public	byte NO_OF_EXAM
			{
				get{ return no_of_exam;}
				set{ no_of_exam=value;}
			}
			public	string IS_UPDATED
			{
				get{ return is_updated;}
				set{ is_updated=value;}
			}
			public	string IS_DELETED
			{
				get{ return is_deleted;}
				set{ is_deleted=value;}
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
		}
}

