//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISModalityexam
		{
			#region Constructor 
			public RISModalityexam(){

			}
			#endregion 


			#region Member 
			private	int modality_exam_id;
			private	int modality_id;
			private	int exam_id;
			private	string tech_bypass;
			private	string qa_bypass;
			private	string is_active;
			private	string is_default_modality;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int MODALITY_EXAM_ID
			{
				get{ return modality_exam_id;}
				set{ modality_exam_id=value;}
			}
			public	int MODALITY_ID
			{
				get{ return modality_id;}
				set{ modality_id=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	string TECH_BYPASS
			{
				get{ return tech_bypass;}
				set{ tech_bypass=value;}
			}
			public	string QA_BYPASS
			{
				get{ return qa_bypass;}
				set{ qa_bypass=value;}
			}
			public	string IS_ACTIVE
			{
				get{ return is_active;}
				set{ is_active=value;}
			}
			public	string IS_DEFAULT_MODALITY
			{
				get{ return is_default_modality;}
				set{ is_default_modality=value;}
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
		}
}

