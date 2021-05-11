//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    21/10/2551 09:57:29
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class XRAYREQ
		{
			#region Constructor 
			public XRAYREQ(){

			}
			#endregion 


			#region Member 
			private	int order_id;
			private	string requestno;
			private	string hn;
			private	string fullname;
			private	DateTime order_dt;
			private	string insurance_type_id;
			private	DateTime order_start_time;
			private	string ref_unit;
			private	string emp_uid;
			private	string docname;
			private	string pat_status;
			private	string ref_doc_instruction;
			private	string clinical_instruction;
			private	string status;
			#endregion 


			#region Property 
			public	int ORDER_ID
			{
				get{ return order_id;}
				set{ order_id=value;}
			}
			public	string REQUESTNO
			{
				get{ return requestno;}
				set{ requestno=value;}
			}
			public	string HN
			{
				get{ return hn;}
				set{ hn=value;}
			}
			public	string FULLNAME
			{
				get{ return fullname;}
				set{ fullname=value;}
			}
			public	DateTime ORDER_DT
			{
				get{ return order_dt;}
				set{ order_dt=value;}
			}
			public	string INSURANCE_TYPE_ID
			{
				get{ return insurance_type_id;}
				set{ insurance_type_id=value;}
			}
			public	DateTime ORDER_START_TIME
			{
				get{ return order_start_time;}
				set{ order_start_time=value;}
			}
			public	string REF_UNIT
			{
				get{ return ref_unit;}
				set{ ref_unit=value;}
			}
			public	string EMP_UID
			{
				get{ return emp_uid;}
				set{ emp_uid=value;}
			}
			public	string DOCNAME
			{
				get{ return docname;}
				set{ docname=value;}
			}
			public	string PAT_STATUS
			{
				get{ return pat_status;}
				set{ pat_status=value;}
			}
			public	string REF_DOC_INSTRUCTION
			{
				get{ return ref_doc_instruction;}
				set{ ref_doc_instruction=value;}
			}
			public	string CLINICAL_INSTRUCTION
			{
				get{ return clinical_instruction;}
				set{ clinical_instruction=value;}
			}
			public	string STATUS
			{
				get{ return status;}
				set{ status=value;}
			}
			#endregion 
		}
}

