//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 02:30:47
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class INVRequisition
		{
			#region Constructor 
			public INVRequisition(){

			}
			#endregion 


			#region Member 
			private	int requisition_id;
            private string requisition_uid;
			private	string requisition_type;
			private	string generate_mode;
			private	int from_unit;
			private	int to_unit;
			private	int generated_by;
			private	DateTime generated_on;
			private	string status;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int REQUISITION_ID
			{
				get{ return requisition_id;}
				set{ requisition_id=value;}
			}
        public string REQUISITION_UID
        {
            get { return requisition_uid; }
            set { requisition_uid = value; }
        }
			public	string REQUISITION_TYPE
			{
				get{ return requisition_type;}
				set{ requisition_type=value;}
			}
			public	string GENERATE_MODE
			{
				get{ return generate_mode;}
				set{ generate_mode=value;}
			}
			public	int FROM_UNIT
			{
				get{ return from_unit;}
				set{ from_unit=value;}
			}
			public	int TO_UNIT
			{
				get{ return to_unit;}
				set{ to_unit=value;}
			}
			public	int GENERATED_BY
			{
				get{ return generated_by;}
				set{ generated_by=value;}
			}
			public	DateTime GENERATED_ON
			{
				get{ return generated_on;}
				set{ generated_on=value;}
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

