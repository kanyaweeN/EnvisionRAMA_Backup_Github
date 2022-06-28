//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:25:39
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.Delete
{
	public class ProcessDeleteRISModalitymaintenancetype : IBusinessLogic
	{
        private RIS_MODALITYMAINTENANCETYPE _rismodalitymaintenancetype;
		private bool useTran;
		public ProcessDeleteRISModalitymaintenancetype()
		{
            _rismodalitymaintenancetype = new RIS_MODALITYMAINTENANCETYPE();
			useTran=false;
		}
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE
        {
			get{return _rismodalitymaintenancetype;}
			set{_rismodalitymaintenancetype=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISModalitymaintenancetypeDeleteData _proc=new RISModalitymaintenancetypeDeleteData();
            _proc.RIS_MODALITYMAINTENANCETYPE = this.RIS_MODALITYMAINTENANCETYPE;
			_proc.Delete();
		}
	}
}

