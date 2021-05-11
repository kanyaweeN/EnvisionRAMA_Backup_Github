//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    14/01/2552 02:19:17
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class INVAuthorization
		{
			#region Constructor 
			public INVAuthorization(){

			}
			#endregion 


			#region Member 
			private	int auth_id;
			private	DateTime auth_dt;
			private	int pr_id;
			private	int item_id;
			private	int emp_id;
			private	int qty;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int AUTH_ID
			{
				get{ return auth_id;}
				set{ auth_id=value;}
			}
			public	DateTime AUTH_DT
			{
				get{ return auth_dt;}
				set{ auth_dt=value;}
			}
			public	int PR_ID
			{
				get{ return pr_id;}
				set{ pr_id=value;}
			}
			public	int ITEM_ID
			{
				get{ return item_id;}
				set{ item_id=value;}
			}
			public	int EMP_ID
			{
				get{ return emp_id;}
				set{ emp_id=value;}
			}
			public	int QTY
			{
				get{ return qty;}
				set{ qty=value;}
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

