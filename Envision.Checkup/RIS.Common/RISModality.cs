//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    26/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISModality
		{
			#region Constructor 
			public RISModality(){

			}
			#endregion 


			#region Member 
			private	int modality_id;
			private	string modality_uid;
			private	string modality_name;
			private	string modality_type;
			private	byte[] allproperties;
			private	bool visible;
			private	int unit_id;
			private	string is_active;
			private	DateTime? start_time;
			private	DateTime? end_time;
			private	byte avg_inv_time;
			private	int room_id;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int MODALITY_ID
			{
				get{ return modality_id;}
				set{ modality_id=value;}
			}
			public	string MODALITY_UID
			{
				get{ return modality_uid;}
				set{ modality_uid=value;}
			}
			public	string MODALITY_NAME
			{
				get{ return modality_name;}
				set{ modality_name=value;}
			}
			public	string MODALITY_TYPE
			{
				get{ return modality_type;}
				set{ modality_type=value;}
			}
			public	byte[] AllProperties
			{
				get{ return allproperties;}
				set{ allproperties=value;}
			}
			public	bool Visible
			{
				get{ return visible;}
				set{ visible=value;}
			}
			public	int UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
			}
			public	DateTime? START_TIME
			{
				get{ return start_time;}
				set{ start_time=value;}
			}
			public	DateTime? END_TIME
			{
				get{ return end_time;}
				set{ end_time=value;}
			}
			public	byte AVG_INV_TIME
			{
				get{ return avg_inv_time;}
				set{ avg_inv_time=value;}
			}
			public	int ROOM_ID
			{
				get{ return room_id;}
				set{ room_id=value;}
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
			#endregion 
		}
}

