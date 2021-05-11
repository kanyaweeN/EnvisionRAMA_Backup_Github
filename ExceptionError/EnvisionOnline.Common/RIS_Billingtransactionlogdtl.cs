//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    23/03/2553 05:48:15
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnvisionOnline.Common
{
	public class RISBillingtransactionlogdtl
		{
			#region Member 
			private	int bill_log_id;
			private	string accession_no;
            private string billing_msg;
            private string billing_ack_msg;
			private	string hn;
			private	string an;
			private	string iseq;
			private	string unit_uid;
			private	DateTime order_dt;
			private	string exam_uid;
			private	int qty;
			private	decimal rate;
			private	decimal amount;
			private	string hr_unit;
			private	string msg_type;
			private	string clinic_type;
			private	string insurance_type_uid;
			private	string hr_emp;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string billing_type;

            private string enc_id;
            private string enc_type;
			#endregion 


			#region Property 
			public	int BILL_LOG_ID
			{
				get{ return bill_log_id;}
				set{ bill_log_id=value;}
			}
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	string BILLING_MSG
			{
				get{ return billing_msg;}
				set{ billing_msg=value;}
			}
            public string BILLING_ACK_MSG
            {
                get { return billing_ack_msg; }
                set { billing_ack_msg = value; }
            }
			public	string HN
			{
				get{ return hn;}
				set{ hn=value;}
			}
			public	string AN
			{
				get{ return an;}
				set{ an=value;}
			}
			public	string ISEQ
			{
				get{ return iseq;}
				set{ iseq=value;}
			}
			public	string UNIT_UID
			{
				get{ return unit_uid;}
				set{ unit_uid=value;}
			}
			public	DateTime ORDER_DT
			{
				get{ return order_dt;}
				set{ order_dt=value;}
			}
			public	string EXAM_UID
			{
				get{ return exam_uid;}
				set{ exam_uid=value;}
			}
			public	int QTY
			{
				get{ return qty;}
				set{ qty=value;}
			}
			public	decimal RATE
			{
				get{ return rate;}
				set{ rate=value;}
			}
			public	decimal AMOUNT
			{
				get{ return amount;}
				set{ amount=value;}
			}
			public	string HR_UNIT
			{
				get{ return hr_unit;}
				set{ hr_unit=value;}
			}
			public	string MSG_TYPE
			{
				get{ return msg_type;}
				set{ msg_type=value;}
			}
			public	string CLINIC_TYPE
			{
				get{ return clinic_type;}
				set{ clinic_type=value;}
			}
			public	string INSURANCE_TYPE_UID
			{
				get{ return insurance_type_uid;}
				set{ insurance_type_uid=value;}
			}
			public	string HR_EMP
			{
				get{ return hr_emp;}
				set{ hr_emp=value;}
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
            public string BILLING_TYPE
            {
                get { return billing_type; }
                set { billing_type = value; }
            }

            public string ENC_ID
            {
                get { return enc_id; }
                set { enc_id = value; }
            }
            public string ENC_TYPE
            {
                get { return enc_type; }
                set { enc_type = value; }
            }
			#endregion 


			#region Constructor 
			public RISBillingtransactionlogdtl(){

			}
			#endregion 


			#region Method 
			public RISBillingtransactionlogdtl Copy()
			{
				return MemberwiseClone() as RISBillingtransactionlogdtl;
			}
			#endregion
		}
}

