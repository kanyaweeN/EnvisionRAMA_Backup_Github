//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    27/05/2552 05:36:57
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
	public class ProcessAddRISInsurancetype : IBusinessLogic
	{
		private RISInsurancetype _risinsurancetype;
		private bool useTran;
		public ProcessAddRISInsurancetype()
		{
			_risinsurancetype = new  RISInsurancetype();
			useTran=false;
		}
		public RISInsurancetype RISInsurancetype
		{
			get{return _risinsurancetype;}
			set{_risinsurancetype=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISInsurancetypeInsertData _proc=new RISInsurancetypeInsertData();
			_proc.RISInsurancetype=this.RISInsurancetype;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

