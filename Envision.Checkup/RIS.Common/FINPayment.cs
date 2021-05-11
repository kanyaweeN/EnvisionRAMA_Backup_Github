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
	public class FINPayment
		{
			#region Member 
			private	long pay_id;
			private	DateTime pay_dt;
			private	long inv_id;
			private	string hn;
			private	int unit_id;
			private	int emp_id;
			private	string status;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private DateTime from_date;
            private DateTime to_date;
            private int order_id;
			#endregion 


			#region Property 
			public	long PAY_ID
			{
				get{ return pay_id;}
				set{ pay_id=value;}
			}
			public	DateTime PAY_DT
			{
				get{ return pay_dt;}
				set{ pay_dt=value;}
			}
			public	long INV_ID
			{
				get{ return inv_id;}
				set{ inv_id=value;}
			}
			public	string HN
			{
				get{ return hn;}
				set{ hn=value;}
			}
			public	int UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
			}
			public	int EMP_ID
			{
				get{ return emp_id;}
				set{ emp_id=value;}
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
            public DateTime FROM_DATE
            {
                get { return from_date; }
                set { from_date = value; }
            }
            public DateTime TO_DATE
            {
                get { return to_date; }
                set { to_date = value; }
            }
            public int ORDER_ID
            {
                get { return order_id; }
                set { order_id = value; }
            }
			#endregion 


			#region Constructor 
			public FINPayment(){

			}
			#endregion 


			#region Method 
			public FINPayment Copy()
			{
				return MemberwiseClone() as FINPayment;
			}
			#endregion
		}
}

