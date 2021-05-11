//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2552 02:48:53
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamtemplateshare
		{
			#region Member 
			private	int template_share_id;
			private	int exam_id;
			private	int template_id;
			private	int share_with;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int TEMPLATE_SHARE_ID
			{
				get{ return template_share_id;}
				set{ template_share_id=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	int TEMPLATE_ID
			{
				get{ return template_id;}
				set{ template_id=value;}
			}
			public	int SHARE_WITH
			{
				get{ return share_with;}
				set{ share_with=value;}
			}
			public	string IS_UPDATED
			{
				get{ return is_updated;}
				set{ is_updated=value;}
			}
			public	string IS_DELETED
			{
				get{ return is_deleted;}
				set{ is_deleted=value;}
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
			public RISExamtemplateshare(){

			}
			#endregion 


			#region Method 
			public RISExamtemplateshare Copy()
			{
				return MemberwiseClone() as RISExamtemplateshare;
			}
			#endregion
		}
}

