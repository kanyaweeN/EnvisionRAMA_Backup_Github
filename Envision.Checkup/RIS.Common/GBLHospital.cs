//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    30/01/2552 03:44:18
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class GBLHospital
		{
			#region Member 
			private	int hos_id;
			private	string hos_uid;
			private	string hos_name;
			private	string hos_name_alias;
			private	string phone_no;
			private	string descr;
			private	int created_by;
            private int percent_discount;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	int org_id;
            private int emp_id;
			#endregion 


			#region Property 
			public	int HOS_ID
			{
				get{ return hos_id;}
				set{ hos_id=value;}
			}
            public int PERCENT_DISCOUNT
            {
                get { return percent_discount; }
                set { percent_discount = value; }
            }
			public	string HOS_UID
			{
				get{ return hos_uid;}
				set{ hos_uid=value;}
			}
			public	string HOS_NAME
			{
				get{ return hos_name;}
				set{ hos_name=value;}
			}
			public	string HOS_NAME_ALIAS
			{
				get{ return hos_name_alias;}
				set{ hos_name_alias=value;}
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
            public int EMP_ID {
                get { return emp_id; }
                set { emp_id = value; }
            }
			#endregion 


			#region Constructor 
			public GBLHospital(){

			}
			#endregion 


			#region Method 
			public GBLHospital Copy()
			{
				return MemberwiseClone() as GBLHospital;
			}
			#endregion
		}
}

