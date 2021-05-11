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
using System.Data;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISModalitymaintenancetype : IBusinessLogic
	{
		private DataSet result;
        private RIS_MODALITYMAINTENANCETYPE _rismodalitymaintenancetype;
		public ProcessGetRISModalitymaintenancetype()
		{
            _rismodalitymaintenancetype = new RIS_MODALITYMAINTENANCETYPE();
		}
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE
		{
			get{return _rismodalitymaintenancetype;}
			set{_rismodalitymaintenancetype=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISModalitymaintenancetypeSelectData _proc=new RISModalitymaintenancetypeSelectData();
            _proc.RIS_MODALITYMAINTENANCETYPE = this.RIS_MODALITYMAINTENANCETYPE;
			result=_proc.GetData();
		}
	}
}

