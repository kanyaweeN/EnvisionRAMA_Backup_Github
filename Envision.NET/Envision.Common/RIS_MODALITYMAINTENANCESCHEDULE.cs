//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:26:58
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Envision.Common
{
	public class RIS_MODALITYMAINTENANCESCHEDULE //RISModalitymaintenanceschedule
		{
			#region Member 
			private	int mtn_sch_id;
			private	int modality_id;
			private	int mtn_type_id;
			private	DateTime mtn_dt;
			private	DateTime start_time;
			private	DateTime end_time;
			private	decimal mtn_cost;
			private	bool disallow_exam;
			private	int responsible_person;
			private	string mtn_sch_status;
			private	string comments;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string mtn_type_whereclause;
            private string mode;
            private string modality_id_whereclause;
            //private string recurrenceinfo;
            //private string reminderinfo;
            //private int recurrence_id;
            private int schedule_id;
            #endregion 


			#region Property 
			public	int MTN_SCH_ID
			{
				get{ return mtn_sch_id;}
				set{ mtn_sch_id=value;}
			}
			public	int MODALITY_ID
			{
				get{ return modality_id;}
				set{ modality_id=value;}
			}
			public	int MTN_TYPE_ID
			{
				get{ return mtn_type_id;}
				set{ mtn_type_id=value;}
			}
			public	DateTime MTN_DT
			{
				get{ return mtn_dt;}
				set{ mtn_dt=value;}
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
			public	decimal MTN_COST
			{
				get{ return mtn_cost;}
				set{ mtn_cost=value;}
			}
			public	bool DISALLOW_EXAM
			{
				get{ return disallow_exam;}
				set{ disallow_exam=value;}
			}
			public	int RESPONSIBLE_PERSON
			{
				get{ return responsible_person;}
				set{ responsible_person=value;}
			}
			public	string MTN_SCH_STATUS
			{
				get{ return mtn_sch_status;}
				set{ mtn_sch_status=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
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
            public string MTN_TYPE_WHERECLAUSE
            {
                get { return mtn_type_whereclause; }
                set { mtn_type_whereclause = value; }
            }
            public string MODE
            {
                get { return mode; }
                set { mode = value; }
            }
            public string MODALITY_ID_WHERECLAUSE
            {
                get { return modality_id_whereclause; }
                set { modality_id_whereclause = value; }
            }
            //public string RECURRENCEINFO
            //{
            //    get { return recurrenceinfo; }
            //    set { recurrenceinfo = value; }
            //}
            //public string REMINDERINFO
            //{
            //    get { return reminderinfo; }
            //    set { reminderinfo = value; }
            //}
            //public int RECURRENCE_ID
            //{
            //    get { return modality_id_whereclause; }
            //    set { modality_id_whereclause = value; }
            //}
            public int SCHEDULE_ID
            {
                get { return schedule_id; }
                set { schedule_id = value; }
            }
			#endregion 


			#region Constructor 
            public RIS_MODALITYMAINTENANCESCHEDULE()
            {

			}
			#endregion 


			#region Method 
            public RIS_MODALITYMAINTENANCESCHEDULE Copy()
			{
                return MemberwiseClone() as RIS_MODALITYMAINTENANCESCHEDULE;
			}
			#endregion
		}
}

