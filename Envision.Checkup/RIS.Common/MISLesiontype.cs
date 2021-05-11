//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class MISLesiontype
		{
			#region Member 
			private	int lesion_type_id;
			private	string lesion_type_uid;
			private	string lesion_type_desc;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int LESION_TYPE_ID
			{
				get{ return lesion_type_id;}
				set{ lesion_type_id=value;}
			}
			public	string LESION_TYPE_UID
			{
				get{ return lesion_type_uid;}
				set{ lesion_type_uid=value;}
			}
			public	string LESION_TYPE_DESC
			{
				get{ return lesion_type_desc;}
				set{ lesion_type_desc=value;}
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


			#region Constructor 
			public MISLesiontype(){

			}
			#endregion 


			#region Method 
			public MISLesiontype Copy()
			{
				return MemberwiseClone() as MISLesiontype;
			}
			#endregion
		}
}

