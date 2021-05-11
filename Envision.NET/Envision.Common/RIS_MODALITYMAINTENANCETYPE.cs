//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:25:38
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Envision.Common
{
	public class RIS_MODALITYMAINTENANCETYPE
		{
			#region Member 
			private	int mtn_type_id;
			private	string mtn_type_uid;
			private	string mtn_type_desc;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int MTN_TYPE_ID
			{
				get{ return mtn_type_id;}
				set{ mtn_type_id=value;}
			}
			public	string MTN_TYPE_UID
			{
				get{ return mtn_type_uid;}
				set{ mtn_type_uid=value;}
			}
			public	string MTN_TYPE_DESC
			{
				get{ return mtn_type_desc;}
				set{ mtn_type_desc=value;}
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
            public RIS_MODALITYMAINTENANCETYPE()
            {

			}
			#endregion 


			#region Method 
            public RIS_MODALITYMAINTENANCETYPE Copy()
			{
                return MemberwiseClone() as RIS_MODALITYMAINTENANCETYPE;
			}
			#endregion
		}
}

