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
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISModalitymaintenancescheduleChangeStatus : IBusinessLogic
	{
        private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
		private bool useTran;
        public ProcessUpdateRISModalitymaintenancescheduleChangeStatus()
		{
            _rismodalitymaintenanceschedule = new RIS_MODALITYMAINTENANCESCHEDULE();
			useTran=false;
		}
        public RIS_MODALITYMAINTENANCESCHEDULE RIS_MODALITYMAINTENANCESCHEDULE		
        {
			get{return _rismodalitymaintenanceschedule;}
			set{_rismodalitymaintenanceschedule=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
            RISModalitymaintenancescheduleUpdateData _proc = new RISModalitymaintenancescheduleUpdateData();
            _proc.RIS_MODALITYMAINTENANCESCHEDULE = this.RIS_MODALITYMAINTENANCESCHEDULE;
			useTran= _proc.UpdateChangeStatus();
		}
	}
}

