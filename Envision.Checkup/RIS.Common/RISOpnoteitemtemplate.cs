//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    02/03/2552 02:02:04
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISOpnoteitemtemplate
		{
			#region Constructor 
			public RISOpnoteitemtemplate(){

			}
			#endregion 


			#region Member 
			private	int op_item_id;
			private	int exam_id;
			private	string item_value;
			private	string item_unit;
			private	string opnote_type;
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
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
        public string ITEM_VALUE
			{
				get{ return item_value;}
				set{ item_value=value;}
			}
			public	string ITEM_UNIT
			{
				get{ return item_unit;}
				set{ item_unit=value;}
			}
			public	string OPNOTE_TYPE
			{
				get{ return opnote_type;}
				set{ opnote_type=value;}
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

