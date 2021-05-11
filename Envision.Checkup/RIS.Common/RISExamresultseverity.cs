//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    21/05/2552 04:00:03
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamresultseverity
		{
			#region Constructor 
			public RISExamresultseverity(){

			}
			#endregion 


			#region Member 
			private	int severity_id;
			private	string severity_uid;
			private	string severity_name;
			private	string severity_label;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private int unit_id;
			#endregion 


			#region Property 
			public	int SEVERITY_ID
			{
				get{ return severity_id;}
				set{ severity_id=value;}
			}
			public	string SEVERITY_UID
			{
				get{ return severity_uid;}
				set{ severity_uid=value;}
			}
			public	string SEVERITY_NAME
			{
				get{ return severity_name;}
				set{ severity_name=value;}
			}
			public	string SEVERITY_LABEL
			{
				get{ return severity_label;}
				set{ severity_label=value;}
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
            public int UNIT_ID
            {
                get { return unit_id; }
                set { unit_id = value; }
            }
			#endregion 
		}
}

