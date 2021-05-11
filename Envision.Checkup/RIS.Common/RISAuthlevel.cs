//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    17/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISAuthlevel
		{
			#region Constructor 
			public RISAuthlevel(){

			}
			#endregion 


			#region Member 
			private	int auth_level_id;
			private	string auth_level_uid;
			private	string auth_level_desc;
			private	byte auth_level_sl;
			private	string auth_level_text;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int AUTH_LEVEL_ID
			{
				get{ return auth_level_id;}
				set{ auth_level_id=value;}
			}
			public	string AUTH_LEVEL_UID
			{
				get{ return auth_level_uid;}
				set{ auth_level_uid=value;}
			}
			public	string AUTH_LEVEL_DESC
			{
				get{ return auth_level_desc;}
				set{ auth_level_desc=value;}
			}
			public	byte AUTH_LEVEL_SL
			{
				get{ return auth_level_sl;}
				set{ auth_level_sl=value;}
			}
			public	string AUTH_LEVEL_TEXT
			{
				get{ return auth_level_text;}
				set{ auth_level_text=value;}
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

