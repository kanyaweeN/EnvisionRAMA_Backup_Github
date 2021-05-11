//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    12/02/2552 11:47:29
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamhospital
		{
			#region Constructor 
			public RISExamhospital(){

			}
			#endregion 


			#region Member 
			private	int exam_id;
			private	int hos_id;
			private	decimal uc_rate;
			private	decimal cr_rate;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	int created_by;
			private	DateTime created_on;
			#endregion 


			#region Property 
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	int HOS_ID
			{
				get{ return hos_id;}
				set{ hos_id=value;}
			}
			public	decimal UC_RATE
			{
				get{ return uc_rate;}
				set{ uc_rate=value;}
			}
			public	decimal CR_RATE
			{
				get{ return cr_rate;}
				set{ cr_rate=value;}
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
			#endregion 
		}
}

