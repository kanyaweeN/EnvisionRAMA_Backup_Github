//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:23
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateMISAsessmenttype : IBusinessLogic
	{
		private MISAsessmenttype _misasessmenttype;
		private bool useTran;
		public ProcessUpdateMISAsessmenttype()
		{
			_misasessmenttype = new MISAsessmenttype();
			useTran=false;
		}
		public MISAsessmenttype MISAsessmenttype		{
			get{return _misasessmenttype;}
			set{_misasessmenttype=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			MISAsessmenttypeUpdateData _proc=new MISAsessmenttypeUpdateData();
			_proc.MISAsessmenttype=this.MISAsessmenttype;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

