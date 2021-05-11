using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_EXAMRESULTTIME
    {
        			#region Member 
			private	string accession_no;
			private	int rad_id;
			private	byte sl_no;
			private	DateTime start_on;
			private	string start_status;
			private	DateTime last_saved_on;
			private	string last_saved_status;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	int RAD_ID
			{
				get{ return rad_id;}
				set{ rad_id=value;}
			}
			public	byte SL_NO
			{
				get{ return sl_no;}
				set{ sl_no=value;}
			}
			public	DateTime START_ON
			{
				get{ return start_on;}
				set{ start_on=value;}
			}
			public	string START_STATUS
			{
				get{ return start_status;}
				set{ start_status=value;}
			}
			public	DateTime LAST_SAVED_ON
			{
				get{ return last_saved_on;}
				set{ last_saved_on=value;}
			}
			public	string LAST_SAVED_STATUS
			{
				get{ return last_saved_status;}
				set{ last_saved_status=value;}
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
            public RIS_EXAMRESULTTIME()
            {

			}
			#endregion 
    }
}
