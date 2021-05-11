//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/10/2552 04:17:35
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Envision.Common
{
	public class RIS_TECHWORKSDTL
		{
			#region Member 
			private	string accession_no;
			private	byte take;
			private	int technologist_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	string ACCESSION_NO
			{
				get{ return accession_no;}
				set{ accession_no=value;}
			}
			public	byte TAKE
			{
				get{ return take;}
				set{ take=value;}
			}
			public	int TECHNOLOGIST_ID
			{
				get{ return technologist_id;}
				set{ technologist_id=value;}
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
            public RIS_TECHWORKSDTL()
            {

			}
			#endregion 


			#region Method 
            public RIS_TECHWORKSDTL Copy()
			{
                return MemberwiseClone() as RIS_TECHWORKSDTL;
			}
			#endregion
		}
}

