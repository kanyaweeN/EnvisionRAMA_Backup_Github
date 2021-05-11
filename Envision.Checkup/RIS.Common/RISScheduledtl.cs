//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    09/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISScheduledtl
		{
			#region Constructor 
			public RISScheduledtl(){

			}
			#endregion 


			#region Member 
			private	int schedule_id;
			private	int exam_id;
			private	int modality_id;
            private int pat_status;
			private	DateTime appoint_dt;
			private	byte qty;
			private	string comments;
			private	string special_clinic;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
        private int selectcase;
			#endregion 


			#region Property 
			public	int SCHEDULE_ID
			{
				get{ return schedule_id;}
				set{ schedule_id=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	int PAT_STATUS
			{
				get{ return pat_status;}
                set { pat_status = value; }
			}
        public int MODALITY_ID
        {
            get { return modality_id; }
            set { modality_id = value; }
        }
			public	DateTime APPOINT_DT
			{
				get{ return appoint_dt;}
				set{ appoint_dt=value;}
			}
			public	byte QTY
			{
				get{ return qty;}
				set{ qty=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
			}
			public	string SPECIAL_CLINIC
			{
				get{ return special_clinic;}
				set{ special_clinic=value;}
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
        public int SELECTCASE
        {
            get { return selectcase; }
            set { selectcase = value; }
        }
			#endregion 
		}
}

