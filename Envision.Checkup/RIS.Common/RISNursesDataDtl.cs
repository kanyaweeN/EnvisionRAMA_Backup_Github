using System;
using System.Collections.Generic;
using System.Text;

namespace RIS.Common
{
    public class RISNursesDataDtl
   {
        			#region Member 

            private int _selectcase;
            private int _NURSE_DATA_UK_ID;
        private int _DETAIL_DATA_ID;
            private DateTime _DETAIL_TIME;
            private string _HR_MIN;
            private string _RR_MIN;
            private string _BP_MMHG;
            private string _O2_SAT;
            private string _CONCSIOUS;
            private string _PROGRESS_NOTE;
            private int _ORG_ID;
            private int _CREATED_BY;
            private DateTime _CREATED_ON;
            private int _LAST_MODIFIED_BY;
            private DateTime _LAST_MODIFIED_ON;

			#endregion 


			#region Property 
        public int SELECTCASE
        {
            get { return _selectcase; }
            set { _selectcase = value; }
        }
			public	int NURSE_DATA_UK_ID
			{
				get{ return _NURSE_DATA_UK_ID;}
				set{ _NURSE_DATA_UK_ID=value;}
			}
        public int DETAIL_DATA_ID
			{
                get { return _DETAIL_DATA_ID; }
                set { _DETAIL_DATA_ID = value; }
			}
			public	DateTime DETAIL_TIME
			{
				get{ return _DETAIL_TIME;}
				set{ _DETAIL_TIME=value;}
			}
			public	string HR_MIN
			{
				get{ return _HR_MIN;}
				set{ _HR_MIN=value;}
			}
			public	string RR_MIN
			{
				get{ return _RR_MIN;}
				set{ _RR_MIN=value;}
			}
			public	string BP_MMHG
			{
				get{ return _BP_MMHG;}
				set{ _BP_MMHG=value;}
			}
			public	string O2_SAT
			{
				get{ return _O2_SAT;}
				set{ _O2_SAT=value;}
			}
			public	string CONCSIOUS
			{
				get{ return _CONCSIOUS;}
				set{ _CONCSIOUS=value;}
			}
			public	string PROGRESS_NOTE
			{
				get{ return _PROGRESS_NOTE;}
				set{ _PROGRESS_NOTE=value;}
			}
			public	int ORG_ID
			{
				get{ return _ORG_ID;}
				set{ _ORG_ID=value;}
			}
			public	int CREATED_BY
			{
				get{ return _CREATED_BY;}
				set{ _CREATED_BY=value;}
			}
			public	DateTime CREATED_ON
			{
				get{ return _CREATED_ON;}
				set{ _CREATED_ON=value;}
			}
			public	int LAST_MODIFIED_BY
			{
				get{ return _LAST_MODIFIED_BY;}
				set{ _LAST_MODIFIED_BY=value;}
			}
			public	DateTime LAST_MODIFIED_ON
			{
				get{ return _LAST_MODIFIED_ON;}
				set{ _LAST_MODIFIED_ON=value;}
			}
			#endregion 


			#region Constructor 
        public RISNursesDataDtl()
        {

			}
			#endregion 


			#region Method 
        public RISNursesDataDtl Copy()
			{
                return MemberwiseClone() as RISNursesDataDtl;
			}
			#endregion

    }
}
