using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_ASSIGNMENT
    {
        #region Member 
			private	int assignement_id;
			private	int enroll_id;
			private	int assigned_by;
			private	string assignment_type;
			private	DateTime assigned_on;
			private	string accession_no;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int ASSIGNEMENT_ID
			{
				get{ return assignement_id;}
				set{ assignement_id=value;}
			}
			public	int ENROLL_ID
			{
				get{ return enroll_id;}
				set{ enroll_id=value;}
			}
			public	int ASSIGNED_BY
			{
				get{ return assigned_by;}
				set{ assigned_by=value;}
			}
			public	string ASSIGNMENT_TYPE
			{
				get{ return assignment_type;}
				set{ assignment_type=value;}
			}
			public	DateTime ASSIGNED_ON
			{
				get{ return assigned_on;}
				set{ assigned_on=value;}
			}
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
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
            public string REPORT_TEXT { get; set; }
            public string REPORT_TYPE { get; set; }
            public int SEVERITY_ID { get; set; }
            public string RESULT_STATUS { get; set; }
			#endregion 


			#region Constructor 
            public AC_ASSIGNMENT()
            {

			}
			#endregion 

    }
}
