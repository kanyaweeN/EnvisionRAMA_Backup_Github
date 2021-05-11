//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    11/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class HISDepartment
		{
			#region Constructor 
			public HISDepartment(){

			}
			#endregion 


			#region Member 
			private	int dep_id;
			private	string dep_name;
			private	string dep_tel;
			#endregion 


			#region Property 
			public	int DEP_ID
			{
				get{ return dep_id;}
				set{ dep_id=value;}
			}
			public	string DEP_NAME
			{
				get{ return dep_name;}
				set{ dep_name=value;}
			}
			public	string DEP_TEL
			{
				get{ return dep_tel;}
				set{ dep_tel=value;}
			}
			#endregion 
		}
}

