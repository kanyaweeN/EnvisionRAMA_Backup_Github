//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    09/06/2552 02:38:16
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISClinicsession
		{
			#region Member 
			private	int session_id;
			private	string session_uid;
			private	string session_name;
			private	int clinic_type_id;
			private	DateTime start_time;
			private	DateTime end_time;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
        private int modality_id;
        private int weekday;
        
			#endregion 


			#region Property 
			public	int SESSION_ID
			{
				get{ return session_id;}
				set{ session_id=value;}
			}
			public	string SESSION_UID
			{
				get{ return session_uid;}
				set{ session_uid=value;}
			}
			public	string SESSION_NAME
			{
				get{ return session_name;}
				set{ session_name=value;}
			}
			public	int CLINIC_TYPE_ID
			{
				get{ return clinic_type_id;}
				set{ clinic_type_id=value;}
			}
			public	DateTime START_TIME
			{
				get{ return start_time;}
				set{ start_time=value;}
			}
			public	DateTime END_TIME
			{
				get{ return end_time;}
				set{ end_time=value;}
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
        public int MODALITY_ID
        {
            get { return modality_id; }
            set { modality_id = value; }
        }
        public int WEEKDAYS
        {
            get { return weekday; }
            set { weekday = value; }
        }
			#endregion 


			#region Constructor 
			public RISClinicsession(){

			}
			#endregion 


			#region Method 
			public RISClinicsession Copy()
			{
				return MemberwiseClone() as RISClinicsession;
			}
			#endregion
		}
}

