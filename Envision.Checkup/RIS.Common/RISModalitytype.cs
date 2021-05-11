//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISModalitytype
		{
			#region Constructor 
        public RISModalitytype(int id, string uid, string name, string alias, string description){
            type_id = id;
			type_uid = uid;
			type_name = name;
			type_name_alias = alias;
			descr = description;
			}
        public RISModalitytype() { }
			#endregion 


			#region Member 
			private	int type_id;
			private	string type_uid;
			private	string type_name;
			private	string type_name_alias;
			private	string descr;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	int org_id;
			#endregion 


			#region Property 
			public	int TYPE_ID
			{
				get{ return type_id;}
				set{ type_id=value;}
			}
			public	string TYPE_UID
			{
				get{ return type_uid;}
				set{ type_uid=value;}
			}
			public	string TYPE_NAME
			{
				get{ return type_name;}
				set{ type_name=value;}
			}
			public	string TYPE_NAME_ALIAS
			{
				get{ return type_name_alias;}
				set{ type_name_alias=value;}
			}
			public	string DESCR
			{
				get{ return descr;}
				set{ descr=value;}
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
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
			}
			#endregion 
		}
}

