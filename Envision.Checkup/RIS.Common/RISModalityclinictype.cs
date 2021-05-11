//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/03/2552 08:28:34
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISModalityclinictype
		{
			#region Member 
			private	int modality_clinictype_id;
			private	int clinic_type_id;
			private	int modality_id;
			private	DateTime start_datetime;
			private	DateTime end_datetime;
			private	int max_app;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private int mode;
            private int clinic_type_id_old;
			#endregion 


			#region Property 
			public	int MODALITY_CLINICTYPE_ID
			{
				get{ return modality_clinictype_id;}
				set{ modality_clinictype_id=value;}
			}
			public	int CLINIC_TYPE_ID
			{
				get{ return clinic_type_id;}
				set{ clinic_type_id=value;}
			}
			public	int MODALITY_ID
			{
				get{ return modality_id;}
				set{ modality_id=value;}
			}
			public	DateTime START_DATETIME
			{
				get{ return start_datetime;}
				set{ start_datetime=value;}
			}
			public	DateTime END_DATETIME
			{
				get{ return end_datetime;}
				set{ end_datetime=value;}
			}
			public	int MAX_APP
			{
				get{ return max_app;}
				set{ max_app=value;}
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
            public int CLINIC_TYPE_ID_OLD
            {
                get { return clinic_type_id_old; }
                set { clinic_type_id_old = value; }
            }
			#endregion 


			#region Constructor 
			public RISModalityclinictype(){

			}
			#endregion 


			#region Method 
			public RISModalityclinictype Copy()
			{
				return MemberwiseClone() as RISModalityclinictype;
			}
			#endregion
		}
}

