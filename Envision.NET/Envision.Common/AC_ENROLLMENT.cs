using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_ENROLLMENT
    {
        	#region Member 
			private	int enroll_id;
			private	string enroll_uid;
			private	int year_id;
			private	int class_id;
			private	int emp_id;
			private	string is_active;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int ENROLL_ID
			{
				get{ return enroll_id;}
				set{ enroll_id=value;}
			}
			public	string ENROLL_UID
			{
				get{ return enroll_uid;}
				set{ enroll_uid=value;}
			}
			public	int YEAR_ID
			{
				get{ return year_id;}
				set{ year_id=value;}
			}
			public	int CLASS_ID
			{
				get{ return class_id;}
				set{ class_id=value;}
			}
			public	int EMP_ID
			{
				get{ return emp_id;}
				set{ emp_id=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
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


			#region Constructor 
            public AC_ENROLLMENT()
            {

			}
			#endregion 

    }
}
