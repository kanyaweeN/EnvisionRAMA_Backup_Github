using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;


namespace EnvisionOnline.Common
{
	public class HRUnit
		{
			#region Member 
			private	int unit_id;
			private	string unit_uid;
			private	int unit_id_parent;
			private	string unit_name;
			private	string unit_name_alias;
			private	string phone_no;
			private	string descr;
			private	string unit_alias;
			private	string unit_type;
			private	string unit_ins;
			private	string is_external;
			private	string loc;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	int org_id;
			#endregion 


			#region Property 
			public	int UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
			}
			public	string UNIT_UID
			{
				get{ return unit_uid;}
				set{ unit_uid=value;}
			}
			public	int UNIT_ID_PARENT
			{
				get{ return unit_id_parent;}
				set{ unit_id_parent=value;}
			}
			public	string UNIT_NAME
			{
				get{ return unit_name;}
				set{ unit_name=value;}
			}
			public	string UNIT_NAME_ALIAS
			{
				get{ return unit_name_alias;}
				set{ unit_name_alias=value;}
			}
			public	string PHONE_NO
			{
				get{ return phone_no;}
				set{ phone_no=value;}
			}
			public	string DESCR
			{
				get{ return descr;}
				set{ descr=value;}
			}
			public	string UNIT_ALIAS
			{
				get{ return unit_alias;}
				set{ unit_alias=value;}
			}
			public	string UNIT_TYPE
			{
				get{ return unit_type;}
				set{ unit_type=value;}
			}
			public	string UNIT_INS
			{
				get{ return unit_ins;}
				set{ unit_ins=value;}
			}
			public	string IS_EXTERNAL
			{
				get{ return is_external;}
				set{ is_external=value;}
			}
			public	string LOC
			{
				get{ return loc;}
				set{ loc=value;}
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


			#region Constructor 
			public HRUnit(){

			}
			#endregion 


			#region Method 
			public HRUnit Copy()
			{
				return MemberwiseClone() as HRUnit;
			}
			#endregion
		}
}

