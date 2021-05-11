//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2552 02:48:52
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISExamresulttemplate
		{
			#region Member 
			private	int template_id;
			private	string template_uid;
			private	int exam_id;
			private	string template_name;
			private	string template_header;
			private	string template_text;
			private	byte[] template_binary;
			private	string template_type;
			private	string auto_apply;
			private	string is_updated;
			private	string is_deleted;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			private	string template_text_rtf;
        private int _SEVERITY_ID;
			#endregion 


			#region Property 
			public	int TEMPLATE_ID
			{
				get{ return template_id;}
				set{ template_id=value;}
			}
			public	string TEMPLATE_UID
			{
				get{ return template_uid;}
				set{ template_uid=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	string TEMPLATE_NAME
			{
				get{ return template_name;}
				set{ template_name=value;}
			}
			public	string TEMPLATE_HEADER
			{
				get{ return template_header;}
				set{ template_header=value;}
			}
			public	string TEMPLATE_TEXT
			{
				get{ return template_text;}
				set{ template_text=value;}
			}
			public	byte[] TEMPLATE_BINARY
			{
				get{ return template_binary;}
				set{ template_binary=value;}
			}
			public	string TEMPLATE_TYPE
			{
				get{ return template_type;}
				set{ template_type=value;}
			}
			public	string AUTO_APPLY
			{
				get{ return auto_apply;}
				set{ auto_apply=value;}
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
			public	string TEMPLATE_TEXT_RTF
			{
				get{ return template_text_rtf;}
				set{ template_text_rtf=value;}
			}
        public int SEVERITY_ID
			{
                get { return _SEVERITY_ID; }
                set { _SEVERITY_ID = value; }
			}
        
			#endregion 


			#region Constructor 
			public RISExamresulttemplate(){

			}
			#endregion 


			#region Method 
			public RISExamresulttemplate Copy()
			{
				return MemberwiseClone() as RISExamresulttemplate;
			}
			#endregion
		}
}

