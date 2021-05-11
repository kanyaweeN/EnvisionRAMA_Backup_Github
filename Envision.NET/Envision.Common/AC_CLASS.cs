using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_CLASS
    {
        	#region Member 
			private	int class_id;
            private string class_alias;
			private	string class_label;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 


			#region Property 
			public	int CLASS_ID
			{
				get{ return class_id;}
				set{ class_id=value;}
			}
            public string CLASS_ALIAS
            {
                get { return class_alias; }
                set { class_alias = value; }
            }
			public	string CLASS_LABEL
			{
				get{ return class_label;}
				set{ class_label=value;}
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
            public AC_CLASS()
            {

			}
			#endregion 
    }
}
