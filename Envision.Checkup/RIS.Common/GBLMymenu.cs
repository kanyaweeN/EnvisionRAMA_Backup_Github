//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    06/08/2552 04:53:42
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class GBLMymenu
		{
			#region Member 
			private	int mymenu_id;
			private	int mymenu_uid;
			private	int emp_id;
			private	int sl_no;
			private	int submenu_id;
			private	int org_id;
			private	string is_active;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int MYMENU_ID
			{
				get{ return mymenu_id;}
				set{ mymenu_id=value;}
			}
			public	int MYMENU_UID
			{
				get{ return mymenu_uid;}
				set{ mymenu_uid=value;}
			}
			public	int EMP_ID
			{
				get{ return emp_id;}
				set{ emp_id=value;}
			}
			public	int SL_NO
			{
				get{ return sl_no;}
				set{ sl_no=value;}
			}
			public	int SUBMENU_ID
			{
				get{ return submenu_id;}
				set{ submenu_id=value;}
			}
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
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


			#region Constructor 
			public GBLMymenu(){

			}
			#endregion 


			#region Method 
			public GBLMymenu Copy()
			{
				return MemberwiseClone() as GBLMymenu;
			}
			#endregion
		}
}

