//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class FINInvoicedtl
		{
			#region Member 
			private	long inv_id;
			private	int exam_id;
			private	int item_id;
			private	byte qty;
			private	decimal rate;
			private	decimal discount;
			private	decimal payable;
			private	string status;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	long INV_ID
			{
				get{ return inv_id;}
				set{ inv_id=value;}
			}
			public	int EXAM_ID
			{
				get{ return exam_id;}
				set{ exam_id=value;}
			}
			public	int ITEM_ID
			{
				get{ return item_id;}
				set{ item_id=value;}
			}
			public	byte QTY
			{
				get{ return qty;}
				set{ qty=value;}
			}
			public	decimal RATE
			{
				get{ return rate;}
				set{ rate=value;}
			}
			public	decimal DISCOUNT
			{
				get{ return discount;}
				set{ discount=value;}
			}
			public	decimal PAYABLE
			{
				get{ return payable;}
				set{ payable=value;}
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


			#region Constructor 
			public FINInvoicedtl(){

			}
			#endregion 


			#region Method 
			public FINInvoicedtl Copy()
			{
				return MemberwiseClone() as FINInvoicedtl;
			}
			#endregion
		}
}

