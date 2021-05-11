//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    27/05/2552 03:41:43
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamtransferlog
		{
			#region Constructor 
			public RISExamtransferlog(){

			}
			#endregion 


			#region Member 
			private	string accession_no;
			private	byte sl_no;
			private	int from_rad;
			private	int to_rad;
			private	string status;
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
			public	byte SL_NO
			{
				get{ return sl_no;}
				set{ sl_no=value;}
			}
			public	int FROM_RAD
			{
				get{ return from_rad;}
				set{ from_rad=value;}
			}
			public	int TO_RAD
			{
				get{ return to_rad;}
				set{ to_rad=value;}
			}
			public	string STATUS
			{
				get{ return status;}
				set{ status=value;}
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

