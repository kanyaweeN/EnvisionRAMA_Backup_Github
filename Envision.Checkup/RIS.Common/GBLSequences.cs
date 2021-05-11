using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class GBLSequences
		{
			#region Constructor 
			public GBLSequences(){

			}
			#endregion 


			#region Member 
			private	string seq_name;
			private	int seed;
			private	int incr;
			private	int curr_val;
			#endregion 


			#region Property 
			public	string Seq_Name
			{
				get{ return seq_name;}
				set{ seq_name=value;}
			}
			public	int Seed
			{
				get{ return seed;}
				set{ seed=value;}
			}
			public	int Incr
			{
				get{ return incr;}
				set{ incr=value;}
			}
			public	int Curr_val
			{
				get{ return curr_val;}
				set{ curr_val=value;}
			}
			#endregion 
		}
}

