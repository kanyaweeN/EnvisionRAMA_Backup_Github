//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/02/2009 11:11:56
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISUserorgmap
		{
			#region Member 
			private	int emp_id;
			private	int access_org_id;
			private	int? unit_id;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
        private int mode;
			#endregion 


			#region Property 
			public	int EMP_ID
			{
				get{ return emp_id;}
				set{ emp_id=value;}
			}
			public	int ACCESS_ORG_ID
			{
				get{ return access_org_id;}
				set{ access_org_id=value;}
			}
			public	int? UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
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
        public int MODE
        {
            get { return mode; }
            set { mode = value; }
        }
			#endregion 


			#region Constructor 
			public RISUserorgmap(){

			}
			#endregion 


			#region Method 
			public RISUserorgmap Copy()
			{
				return MemberwiseClone() as RISUserorgmap;
			}
			#endregion
		}
}

