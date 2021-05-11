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
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.Update
{
	public class ProcessUpdateRISModalitymaintenancetype : IBusinessLogic
	{
        private RIS_MODALITYMAINTENANCETYPE _rismodalitymaintenancetype;
		private bool useTran;
		public ProcessUpdateRISModalitymaintenancetype()
		{
            RIS_MODALITYMAINTENANCETYPE = new RIS_MODALITYMAINTENANCETYPE();
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
			RISModalitymaintenancetypeUpdateData _proc=new RISModalitymaintenancetypeUpdateData();
            _proc.RIS_MODALITYMAINTENANCETYPE = this.RIS_MODALITYMAINTENANCETYPE;
            //useTran = useTran ? _proc.Update(useTran, true) : _proc.Update();
            _proc.Update();
		}
	}
}

