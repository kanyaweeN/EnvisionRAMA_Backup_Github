//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISClinictype
		{
			#region Constructor 
			public RISClinictype(){

			}
			#endregion 


			#region Member 
			private	int clinic_type_id;
			private	string clinic_type_uid;
			private	string clinic_type_text;
			private	string is_default;
			private	string is_active;
			private	decimal rate_increase;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	int org_id;
			#endregion 


			#region Property 
			public	int CLINIC_TYPE_ID
			{
				get{ return clinic_type_id;}
				set{ clinic_type_id=value;}
			}
			public	string CLINIC_TYPE_UID
			{
				get{ return clinic_type_uid;}
				set{ clinic_type_uid=value;}
			}
			public	string CLINIC_TYPE_TEXT
			{
				get{ return clinic_type_text;}
				set{ clinic_type_text=value;}
			}
			public	string IS_DEFAULT
			{
				get{ return is_default;}
				set{ is_default=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
			}
			public	decimal RATE_INCREASE
			{
				get{ return rate_increase;}
				set{ rate_increase=value;}
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

