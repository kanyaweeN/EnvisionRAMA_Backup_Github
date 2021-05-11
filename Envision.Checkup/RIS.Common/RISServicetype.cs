//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    04/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISServicetype
		{
			#region Constructor 
        public RISServicetype(int id, string uid, string text, string active, string isupdated, string isdeleted)
        {
			    service_type_id = id;
			    service_type_uid = uid;
                service_type_text = text;        
			    is_active = active;
                is_updated = isupdated;
                is_deleted = isdeleted;
	    }
        public RISServicetype() { }

			#endregion 


			#region Member 
			private	int service_type_id;
			private	string service_type_uid;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	string is_active;
			private	string service_type_text;
			#endregion 


			#region Property 
			public	int SERVICE_TYPE_ID
			{
				get{ return service_type_id;}
				set{ service_type_id=value;}
			}
			public	string SERVICE_TYPE_UID
			{
				get{ return service_type_uid;}
				set{ service_type_uid=value;}
			}
			public	string IS_UPDATED
			{
				get{ return is_updated;}
				set{ is_updated=value;}
			}
			public	string IS_DELETED
			{
				get{ return is_deleted;}
				set{ is_deleted=value;}
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
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
			}
			public	string SERVICE_TYPE_TEXT
			{
				get{ return service_type_text;}
				set{ service_type_text=value;}
			}
			#endregion 
		}
}

