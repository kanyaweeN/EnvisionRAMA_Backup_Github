using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{
	public class HISDoctor
		{
			#region Constructor 
			public HISDoctor(){

			}
			#endregion 


			#region Member 
			private	int doc_id;
			private	string fname;
			private	string mname;
			private	string lname;
			#endregion 


			#region Property 
			public	int DOC_ID
			{
				get{ return doc_id;}
				set{ doc_id=value;}
			}
			public	string FNAME
			{
				get{ return fname;}
				set{ fname=value;}
			}
			public	string MNAME
			{
				get{ return mname;}
				set{ mname=value;}
			}
			public	string LNAME
			{
				get{ return lname;}
				set{ lname=value;}
			}
			#endregion 
		}
}

