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
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetMISAsessmenttype : IBusinessLogic
	{
		private DataSet result;
		private MISAsessmenttype _misasessmenttype;
		public ProcessGetMISAsessmenttype()
		{
			_misasessmenttype = new  MISAsessmenttype();
		}
		public MISAsessmenttype MISAsessmenttype
		{
			get{return _misasessmenttype;}
			set{_misasessmenttype=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			MISAsessmenttypeSelectData _proc=new MISAsessmenttypeSelectData();
			_proc.MISAsessmenttype=this.MISAsessmenttype;
			result=_proc.GetData();
		}
	}
}

