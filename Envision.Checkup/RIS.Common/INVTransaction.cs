//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    04/11/2551 03:33:48
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public enum TranferType
    {
        T,R,D,L,E
    }
    public enum Status
    {
        N,U,F,C
    }
	public class INVTransaction
		{
			#region Constructor 
			public INVTransaction(){

			}
			#endregion 


			#region Member 
			private	int txn_id;
            private TranferType txn_type;
			private	int requisition_id;
			private	int po_id;
			private	int from_unit;
			private	int to_unit;
			private	string comments;
			private	int org_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
            private Status _Status;
            private string _Doc;
            private string _xmlDoc;
			#endregion 


			#region Property 
        public Status STATUS
        {
            get { return _Status; }
            set { _Status = value; }
        }
			public	int TXN_ID
			{
				get{ return txn_id;}
				set{ txn_id=value;}
			}
            public TranferType TXN_TYPE
			{
				get{ return txn_type;}
				set{ txn_type=value;}
			}
			public	int REQUISITION_ID
			{
				get{ return requisition_id;}
				set{ requisition_id=value;}
			}
			public	int PO_ID
			{
				get{ return po_id;}
				set{ po_id=value;}
			}
			public	int FROM_UNIT
			{
				get{ return from_unit;}
				set{ from_unit=value;}
			}
			public	int TO_UNIT
			{
				get{ return to_unit;}
				set{ to_unit=value;}
			}
			public	string COMMENTS
			{
				get{ return comments;}
				set{ comments=value;}
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
        public string Doc
            {
                get { return _Doc; }
                set { _Doc = value; }
            }
        public string xmlDoc
            {
                get { return _xmlDoc; }
                set { _xmlDoc = value; }
            }
			#endregion 
		}
}

