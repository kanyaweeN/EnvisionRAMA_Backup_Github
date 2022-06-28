using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Envision.Common
{
    public class RIS_REJECTCAPTURELOG
    {
        #region Member 
	    private	int reject_id;
        private	string accession_no;
	    private	int reason_id;
        private	string comments;
	    private	string phone_call_back;
	    private	int sl_no;
	    private	int created_by;
	    private	DateTime created_on;
	    private	int last_modified_by;
	    private	DateTime last_modified_on;
	    #endregion 

	    #region Property 
	    public	int REJECT_ID
	    {
		    get{ return reject_id;}
		    set{ reject_id=value;}
	    }
	    public	string ACCESSION_NO
	    {
		    get{ return accession_no;}
		    set{ accession_no=value;}
	    }
        public	int REASON_ID
	    {
		    get{ return reason_id;}
		    set{ reason_id=value;}
	    }
	    public	string COMMENTS
	    {
		    get{ return comments;}
		    set{ comments=value;}
	    }
	    public	string PHONE_CALL_BACK
	    {
		    get{ return phone_call_back;}
		    set{ phone_call_back=value;}
	    }
	    public	int SL_NO
	    {
		    get{ return sl_no;}
		    set{ sl_no=value;}
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
        public RIS_REJECTCAPTURELOG()
        {

	    }
	    #endregion 

    }
}
