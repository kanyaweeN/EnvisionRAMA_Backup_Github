//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:28
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class INVPo
		{
			#region Constructor 
			public INVPo(){

			}
			#endregion 


			#region Member 
			private	int po_id;
			private	string po_uid;
			private	int pr_id;
			private	DateTime generated_on;
			private	int vendor_id;
			private	string toc;
			private	string po_status;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int PO_ID
			{
				get{ return po_id;}
				set{ po_id=value;}
			}
			public	string PO_UID
			{
				get{ return po_uid;}
				set{ po_uid=value;}
			}
			public	int PR_ID
			{
				get{ return pr_id;}
				set{ pr_id=value;}
			}
			public	DateTime GENERATED_ON
			{
				get{ return generated_on;}
				set{ generated_on=value;}
			}
			public	int VENDOR_ID
			{
				get{ return vendor_id;}
				set{ vendor_id=value;}
			}
			public	string TOC
			{
				get{ return toc;}
				set{ toc=value;}
			}
			public	string PO_STATUS
			{
				get{ return po_status;}
				set{ po_status=value;}
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

