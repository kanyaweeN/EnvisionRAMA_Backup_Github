//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/03/2552 08:28:36
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISModalityclinictype : IBusinessLogic
	{
		private DataSet result;
		private RISModalityclinictype _rismodalityclinictype;
        private RISSchedule _risschedule;

		public ProcessGetRISModalityclinictype()
		{
			_rismodalityclinictype = new  RISModalityclinictype();
            _risschedule = new RISSchedule();
		}
		
        public RISModalityclinictype RISModalityclinictype
		{
			get{return _rismodalityclinictype;}
			set{_rismodalityclinictype=value;}
		}
        public RISSchedule RISSchedule
        {
            get { return _risschedule; }
            set { _risschedule = value; }
        }

        public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		
        public void Invoke()
		{
			RISModalityclinictypeSelectData _proc=new RISModalityclinictypeSelectData();
			_proc.RISModalityclinictype=this.RISModalityclinictype;
			result=_proc.GetData();
		}

        public void Invoke(int mode)
        {
            RISModalityclinictypeSelectData _proc = new RISModalityclinictypeSelectData();
            _proc.RISModalityclinictype = this.RISModalityclinictype;
            _proc.RISModalityclinictype.MODE = mode;
            result = _proc.GetExamClinicType();
        }

        public DataTable GetCheckMax() {
            RISModalityclinictypeSelectData _proc = new RISModalityclinictypeSelectData();
            _proc.RISSchedule = RISSchedule;
            return _proc.GetCheckTime().Tables[0].Copy();
        }
	}
}

