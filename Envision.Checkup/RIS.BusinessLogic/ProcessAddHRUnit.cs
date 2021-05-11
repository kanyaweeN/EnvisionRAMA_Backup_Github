//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 03:51:49
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddHRUnit : IBusinessLogic
	{
		private HRUnit _hrunit;
		private bool useTran;
		public ProcessAddHRUnit()
		{
			_hrunit = new  HRUnit();
			useTran=false;
		}
		public HRUnit HRUnit
		{
			get{return _hrunit;}
			set{_hrunit=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			HRUnitInsertData _proc=new HRUnitInsertData();
			_proc.HRUnit=this.HRUnit;
			HRUnit.UNIT_ID=_proc.Add();
		}
	}
}

