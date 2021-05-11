//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    23/12/2551 12:15:50
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RIS.Common
{
	public class INVPr
		{
			#region Constructor 
			public INVPr(){

			}
			#endregion 


			#region Member 
			private	int pr_id;
			private	string pr_uid;
			private	string generate_mode;
			private	int generated_by;
			private	DateTime generated_on;
			private	string pr_status;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int PR_ID
			{
				get{ return pr_id;}
				set{ pr_id=value;}
			}
			public	string PR_UID
			{
				get{ return pr_uid;}
				set{ pr_uid=value;}
			}
			public	string GENERATE_MODE
			{
				get{ return generate_mode;}
				set{ generate_mode=value;}
			}
			public	int GENERATED_BY
			{
				get{ return generated_by;}
				set{ generated_by=value;}
			}
			public	DateTime GENERATED_ON
			{
				get{ return generated_on;}
				set{ generated_on=value;}
			}
			public	string PR_STATUS
			{
				get{ return pr_status;}
				set{ pr_status=value;}
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

