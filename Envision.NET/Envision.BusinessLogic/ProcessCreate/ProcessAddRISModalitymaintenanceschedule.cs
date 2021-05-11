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
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic
{
	public class ProcessAddRISModalitymaintenanceschedule : IBusinessLogic
	{
		private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
		private bool useTran;
		public ProcessAddRISModalitymaintenanceschedule()
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
			RISModalitymaintenancescheduleInsertData _proc=new RISModalitymaintenancescheduleInsertData();
            _proc.RIS_MODALITYMAINTENANCESCHEDULE = this.RIS_MODALITYMAINTENANCESCHEDULE;
			_proc.Add();
		}
	}
}

