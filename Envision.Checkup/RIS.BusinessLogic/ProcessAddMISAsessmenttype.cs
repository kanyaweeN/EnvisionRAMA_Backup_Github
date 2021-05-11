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
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddMISAsessmenttype : IBusinessLogic
	{
		private MISAsessmenttype _misasessmenttype;
		private bool useTran;
		public ProcessAddMISAsessmenttype()
		{
			_misasessmenttype = new  MISAsessmenttype();
			useTran=false;
		}
		public MISAsessmenttype MISAsessmenttype
		{
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
			MISAsessmenttypeInsertData _proc=new MISAsessmenttypeInsertData();
			_proc.MISAsessmenttype=this.MISAsessmenttype;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

