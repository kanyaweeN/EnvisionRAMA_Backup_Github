using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class AC_GRADE
    {
        #region Member 
			private	int grade_id;
			private	string grade_label;
            private string grade_value;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
			#endregion 
            
            public string SEND_MESSAGE { get; set; }

			#region Property 
			public	int GRADE_ID
			{
				get{ return grade_id;}
				set{ grade_id=value;}
			}
			public	string GRADE_LABEL
			{
				get{ return grade_label;}
				set{ grade_label=value;}
			}
            public string GRADE_VALUE
            {
                get { return grade_value; }
                set { grade_value = value; }
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
            public AC_GRADE()
            {

			}
			#endregion 
    }
}
