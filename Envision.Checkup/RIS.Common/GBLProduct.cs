//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    27/06/2551 05:26:45
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class GBLProduct
		{
			#region Constructor 
			public GBLProduct(){

			}
			#endregion 


			#region Member 
			private	int prod_id;
			private	string prod_uid;
			private	string prod_name;
			private	string prod_descr;
			private	string prod_version;
			private	DateTime release_dt;
			private	string prod_type;
			private	string licensed_to;
			private	string license_type;
			private	DateTime valid_until;
			private	string force_license;
			private	string copy_right;
			private	int org_id;
			private	string created_by;
			private	DateTime created_on;
			private	string last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int PROD_ID
			{
				get{ return prod_id;}
				set{ prod_id=value;}
			}
			public	string PROD_UID
			{
				get{ return prod_uid;}
				set{ prod_uid=value;}
			}
			public	string PROD_NAME
			{
				get{ return prod_name;}
				set{ prod_name=value;}
			}
			public	string PROD_DESCR
			{
				get{ return prod_descr;}
				set{ prod_descr=value;}
			}
			public	string PROD_VERSION
			{
				get{ return prod_version;}
				set{ prod_version=value;}
			}
			public	DateTime RELEASE_DT
			{
				get{ return release_dt;}
				set{ release_dt=value;}
			}
			public	string PROD_TYPE
			{
				get{ return prod_type;}
				set{ prod_type=value;}
			}
			public	string LICENSED_TO
			{
				get{ return licensed_to;}
				set{ licensed_to=value;}
			}
			public	string LICENSE_TYPE
			{
				get{ return license_type;}
				set{ license_type=value;}
			}
			public	DateTime VALID_UNTIL
			{
				get{ return valid_until;}
				set{ valid_until=value;}
			}
			public	string FORCE_LICENSE
			{
				get{ return force_license;}
				set{ force_license=value;}
			}
			public	string COPY_RIGHT
			{
				get{ return copy_right;}
				set{ copy_right=value;}
			}
			public	int ORG_ID
			{
				get{ return org_id;}
				set{ org_id=value;}
			}
			public	string CREATED_BY
			{
				get{ return created_by;}
				set{ created_by=value;}
			}
			public	DateTime CREATED_ON
			{
				get{ return created_on;}
				set{ created_on=value;}
			}
			public	string LAST_MODIFIED_BY
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

