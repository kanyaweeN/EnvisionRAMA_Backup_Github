//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    12/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISPaticd
		{
			#region Constructor 
			public RISPaticd(){

			}
			#endregion 


			#region Member 
			private	int pat_icd_id;
			private	int icd_id;
			private	string hn;
			private	int order_no;
			private	string accession_no;
			private	string order_result_flag;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int PAT_ICD_ID
			{
				get{ return pat_icd_id;}
				set{ pat_icd_id=value;}
			}
			public	int ICD_ID
			{
				get{ return icd_id;}
				set{ icd_id=value;}
			}
			public	string HN
			{
				get{ return hn;}
				set{ hn=value;}
			}
			public	int ORDER_NO
			{
				get{ return order_no;}
				set{ order_no=value;}
			}
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	string ORDER_RESULT_FLAG
			{
				get{ return order_result_flag;}
				set{ order_result_flag=value;}
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

