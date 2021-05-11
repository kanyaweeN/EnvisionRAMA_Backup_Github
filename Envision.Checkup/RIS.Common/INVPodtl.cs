//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:27
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class INVPodtl
		{
			#region Constructor 
			public INVPodtl(){

			}
			#endregion 


			#region Member 
			private	int po_id;
			private	int item_id;
			private	decimal qty;
			private	string po_item_status;
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
			public	int ITEM_ID
			{
				get{ return item_id;}
				set{ item_id=value;}
			}
			public	decimal QTY
			{
				get{ return qty;}
				set{ qty=value;}
			}
			public	string PO_ITEM_STATUS
			{
				get{ return po_item_status;}
				set{ po_item_status=value;}
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

