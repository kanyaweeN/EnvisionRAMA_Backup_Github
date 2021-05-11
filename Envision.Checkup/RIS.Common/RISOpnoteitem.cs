//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    02/03/2552 02:02:06
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISOpnoteitem
		{
			#region Constructor 
			public RISOpnoteitem(){

			}
			#endregion 


			#region Member 
			private	int op_item_id;
			private	string op_item_uid;
			private	string op_item_name;
			private	int unit_id;
			private	string is_deleted;
			private	string is_active;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int OP_ITEM_ID
			{
				get{ return op_item_id;}
				set{ op_item_id=value;}
			}
			public	string OP_ITEM_UID
			{
				get{ return op_item_uid;}
				set{ op_item_uid=value;}
			}
			public	string OP_ITEM_NAME
			{
				get{ return op_item_name;}
				set{ op_item_name=value;}
			}
			public	int UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
			}
			public	string IS_DELETED
			{
				get{ return is_deleted;}
				set{ is_deleted=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
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

