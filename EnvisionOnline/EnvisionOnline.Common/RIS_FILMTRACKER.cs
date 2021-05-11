//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2553 01:30:45
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace EnvisionOnline.Common
{
        public class RIS_FILMTRACKER
		{
			#region Member 
			private	int tracking_id;
			private	string accession_no;
			private	string issue_type;
			private	int issued_by;
            private int? issued_to;
			private	DateTime issued_on;
			private	DateTime returned_on;
			private	int returned_by;
			private	int returned_to;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private string hn;
			#endregion 


			#region Property 
			public	int TRACKING_ID
			{
				get{ return tracking_id;}
				set{ tracking_id=value;}
			}
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	string ISSUE_TYPE
			{
				get{ return issue_type;}
				set{ issue_type=value;}
			}
			public	int ISSUED_BY
			{
				get{ return issued_by;}
				set{ issued_by=value;}
			}
			public	int? ISSUED_TO
			{
				get{ return issued_to;}
				set{ issued_to=value;}
			}
			public	DateTime ISSUED_ON
			{
				get{ return issued_on;}
				set{ issued_on=value;}
			}
			public	DateTime RETURNED_ON
			{
				get{ return returned_on;}
				set{ returned_on=value;}
			}
			public	int RETURNED_BY
			{
				get{ return returned_by;}
				set{ returned_by=value;}
			}
			public	int RETURNED_TO
			{
				get{ return returned_to;}
				set{ returned_to=value;}
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
            public string HN
            {
                get{ return hn;}
                set{ hn = value; }
            }
			#endregion 


			#region Constructor 
            public RIS_FILMTRACKER()
            {

			}
			#endregion 


			#region Method 
            public RIS_FILMTRACKER Copy()
			{
                return MemberwiseClone() as RIS_FILMTRACKER;
			}
			#endregion
        }
}

