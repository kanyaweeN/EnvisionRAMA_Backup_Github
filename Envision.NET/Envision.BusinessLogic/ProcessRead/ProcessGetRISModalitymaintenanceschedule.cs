//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:26:58
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISModalitymaintenanceschedule : IBusinessLogic
	{
		private DataSet result;
        private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
        private int mode = 0;
		public ProcessGetRISModalitymaintenanceschedule()
		{
			_rismodalitymaintenanceschedule = new  RIS_MODALITYMAINTENANCESCHEDULE();
            this.mode = 0;
		}
        public ProcessGetRISModalitymaintenanceschedule(int mode)
        {
            // 0 = worklist
            // 1 = Report
            // 2 = Schedule
            _rismodalitymaintenanceschedule = new RIS_MODALITYMAINTENANCESCHEDULE();
            this.mode = mode;
        }
        public RIS_MODALITYMAINTENANCESCHEDULE RIS_MODALITYMAINTENANCESCHEDULE
		{
            get { return _rismodalitymaintenanceschedule; }
            set { _rismodalitymaintenanceschedule = value; }
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISModalitymaintenancescheduleSelectData _proc = new RISModalitymaintenancescheduleSelectData(mode);
            _proc.RIS_MODALITYMAINTENANCESCHEDULE = this.RIS_MODALITYMAINTENANCESCHEDULE;
			result=_proc.GetData();
		}
	}
}

