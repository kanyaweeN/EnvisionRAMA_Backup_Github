//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    21/05/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISOrderimages
		{
			#region Constructor 
			public RISOrderimages(){

			}
			#endregion 


			#region Member 
			private	int order_image_id;
			private	string hn;
			private	int order_id;
			private	byte sl_no;
			private	string image_name;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string is_deleted;// IS_DELETED;  
        private int schedule_id;
			#endregion 


			#region Property 
			public	int ORDER_IMAGE_ID
			{
				get{ return order_image_id;}
				set{ order_image_id=value;}
			}
			public	string HN
			{
				get{ return hn;}
				set{ hn=value;}
			}
			public	int ORDER_ID
			{
				get{ return order_id;}
				set{ order_id=value;}
			}
			public	byte SL_NO
			{
				get{ return sl_no;}
				set{ sl_no=value;}
			}
			public	string IMAGE_NAME
			{
				get{ return image_name;}
				set{ image_name=value;}
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
            public string IS_DELETED {
                get { return is_deleted; }
                set { is_deleted = value; }
            }
        public int SCHEDULE_ID
        {
            get { return schedule_id; }
            set { schedule_id = value; }
        }
			#endregion 
		}
}

