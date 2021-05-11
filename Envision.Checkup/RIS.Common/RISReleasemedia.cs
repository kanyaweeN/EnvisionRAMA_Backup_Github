//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
	public class RISReleasemedia
		{
			#region Member 
        private int selectcase;
        private DateTime Fromdate;
        private DateTime Todate;

			private	int release_id;
        private int order_id;
        private int exam_id;
        private string hn;
			private	DateTime release_date;
			private	string request_by;
			private	int request_by_id;
			private	string media_type;
			private	string received_by;
			private	string reason;
			private	string comment;
			private	int unit_id;
			private	int created_by;
			private	DateTime created_on;
			private	int last_modified_by;
			private	DateTime last_modified_on;
        private string _accession;
        private byte _qty;
			#endregion 


			#region Property 
        public int SELECTCASE
        {
            get { return selectcase; }
            set { selectcase = value; }
        }
        public DateTime FROMDATE
        {
            get { return Fromdate; }
            set { Fromdate = value; }
        }
        public DateTime TODATE
        {
            get { return Todate; }
            set { Todate = value; }
        }
			public	int RELEASE_ID
			{
				get{ return release_id;}
				set{ release_id=value;}
			}
        public int ORDER_ID
        {
            get { return order_id; }
            set { order_id = value; }
        }
        public int EXAM_ID
        {
            get { return exam_id; }
            set { exam_id = value; }
        }
        public string HN
        {
            get { return hn; }
            set { hn = value; }
        }
			public	DateTime RELEASE_DATE
			{
				get{ return release_date;}
				set{ release_date=value;}
			}
			public	string REQUEST_BY
			{
				get{ return request_by;}
				set{ request_by=value;}
			}
			public	int REQUEST_BY_ID
			{
				get{ return request_by_id;}
				set{ request_by_id=value;}
			}
			public	string MEDIA_TYPE
			{
				get{ return media_type;}
				set{ media_type=value;}
			}
			public	string RECEIVED_BY
			{
				get{ return received_by;}
				set{ received_by=value;}
			}
			public	string REASON
			{
				get{ return reason;}
				set{ reason=value;}
			}
			public	string COMMENT
			{
				get{ return comment;}
				set{ comment=value;}
			}
			public	int UNIT_ID
			{
				get{ return unit_id;}
				set{ unit_id=value;}
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
        public string ACCESSION_NO
        {
            get { return _accession; }
            set { _accession = value; }
        }
        public byte QTY
        {
            get { return _qty; }
            set { _qty = value; }
        }
			#endregion 


			#region Constructor 
			public RISReleasemedia(){

			}
			#endregion 


			#region Method 
			public RISReleasemedia Copy()
			{
				return MemberwiseClone() as RISReleasemedia;
			}
			#endregion
		}
}

